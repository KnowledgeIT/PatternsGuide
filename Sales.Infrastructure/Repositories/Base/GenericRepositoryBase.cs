using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.CrossCutting.Helpers;
using Sales.Infrastructure.Contexts;
using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.UoW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories.Base
{
    public abstract class GenericRepositoryBase : IGenericRepositoryBase
    {
        #region Fields

        protected readonly Context _context;
        protected readonly IMapper _mapper;

        #endregion

        #region Constructor

        public GenericRepositoryBase(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Generic Methods

        /// <summary>
        /// Adiciona uma nova entidade ao repositório
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Inclui vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task AddAsync<T>(IList<T> list)
        {
            await _context.AddRangeAsync(list);
        }

        /// <summary>
        /// Remove a entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Remove várias entidades do repositório 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete<T>(IList<T> entity) where T : class
        {
            _context.Set<T>().RemoveRange(entity);
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync<T>(int id) where T : class
        {
            var obj = await GetAsync<T>(id);
            if (obj != null)
                _context.Set<T>().Remove(obj);
        }

        /// <summary>
        /// Remove a Entidade do Context.
        /// Abre a possibilidade de ser utilizada para entidades de repositórios diferentes da Entidade principal
        /// </summary>
        /// <param name="entity"></param>
        public virtual void DetachEntity<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id">Long</param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync<T>(long id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Retorna uma lista de todos os itens de uma entidade passada como parâmetro para o repositório
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual async Task<IList<T>> ListAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Retorna uma lista de todos os itens de uma entidade passada como parâmetro para o repositório
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> List<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Marca para atualização a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update<T>(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Atualiza vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual void Update<T>(IList<T> list)
        {
            _context.Set<IList<T>>().UpdateRange(list);
        }

        /// <summary>
        /// Atualiza itens do repositório de forma asyncrona
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task UpdateAsync<T>(T entity)
        {
            await Task.Run(() =>
            {
                _context.Entry(entity).State = EntityState.Modified;
            });
        }

        /// <summary>
        /// Utilizado para retornar resutados paginados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual PagedList<T> GetPagedList<T>(int page, int pageSize) where T : class
        {
            return GetPagedList(List<T>(), page, pageSize);
        }

        /// <summary>
        /// Utilizado para retornar resutados paginados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual PagedList<T> GetPagedList<T>(IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedList<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        #endregion
    }
}