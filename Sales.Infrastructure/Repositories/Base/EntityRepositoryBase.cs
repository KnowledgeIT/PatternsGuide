using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Contexts;
using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.UoW.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories.Base
{
    public abstract class EntityRepositoryBase<TEntity> : GenericRepositoryBase, IEntityRepositoryBase<TEntity> 
        where TEntity : class
    {
        #region Constructor

        public EntityRepositoryBase(Context context, IMapper mapper): base(context, mapper)
        {
        }

        #endregion

        #region Entity Methods

        /// <summary>
        /// Adiciona uma nova entidade ao repositório
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        /// <summary>
        /// Inclui vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task AddAsync(IList<TEntity> list)
        {
            await _context.AddRangeAsync(list);
        }

        /// <summary>
        /// Remove a entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Remove várias entidades do repositório 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(IList<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(int id)
        {
            var obj = await GetEntityAsync(id);
            if (obj != null)
                _context.Set<TEntity>().Remove(obj);
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(long id)
        {
            var obj = await GetEntityAsync(id);
            if (obj != null)
                _context.Set<TEntity>().Remove(obj);
        }

        /// <summary>
        /// Remove a Entidade do Context.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void DetachEntity(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetEntityAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id">Long</param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetEntityAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Retorna uma lista de todos os itens do repositório
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IList<TEntity>> ListEntityAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Retorna uma lista de todos os itens do repositório
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> ListEntity()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// Marca para atualização a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Marca para atualização a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
                {
                    _context.Entry(entity).State = EntityState.Modified;
                });
        }

        /// <summary>
        /// Atualiza vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual void Update(IList<TEntity> list)
        {
            _context.Set<IList<TEntity>>().UpdateRange(list);
        }

        #endregion
    }
}