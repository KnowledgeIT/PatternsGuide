using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories.Base
{
    public abstract class EntityRepositoryBase<TEntity, TDto> : GenericRepositoryBase, IEntityRepositoryBase<TEntity, TDto> 
        where TEntity : class
        where TDto : class
    {
        #region Constructor

        public EntityRepositoryBase(Context context, IMapper mapper, IUnitOfWork unitOfWork): base(context, mapper, unitOfWork)
        {
        }

        #endregion

        #region Entity Methods

        /// <summary>
        /// Adiciona uma nova entidade ao repositório
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Inclui vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task<IList<TEntity>> AddAsync(IList<TEntity> list)
        {
            await _context.AddRangeAsync(list);
            await _unitOfWork.SaveChangesAsync();
            return list;
        }

        /// <summary>
        /// Remove a entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Remove várias entidades do repositório 
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Delete(IList<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var obj = await GetEntityAsync(id);
            if (obj != null)
                _context.Set<TEntity>().Remove(obj);

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(long id)
        {
            var obj = await GetEntityAsync(id);
            if (obj != null)
                _context.Set<TEntity>().Remove(obj);

            return await _unitOfWork.SaveChangesAsync();
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
        public virtual bool Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Marca para atualização a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
                {
                    _context.Entry(entity).State = EntityState.Modified;
                });

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual bool Update(IList<TEntity> list)
        {
            _context.Set<IList<TEntity>>().UpdateRange(list);
            return _unitOfWork.SaveChanges();
        }

        #endregion

        #region DTO Methods

        /// <summary>
        /// Adiciona uma nova entidade recebendo uma DTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            return _mapper.Map<TEntity, TDto>(
                await AddAsync(_mapper.Map<TDto, TEntity>(dto)));
        }

        /// <summary>
        /// Adiciona uma lista de entidades por uma lista de DTOs
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual async Task<IList<TDto>> AddAsync(IList<TDto> list)
        {
            return _mapper.Map<IList<TEntity>, IList<TDto>>(
                await AddAsync(_mapper.Map<IList<TDto>, IList<TEntity>>(list)));
        }

        /// <summary>
        /// Deletes or Removes an Entity por uma DTO
        /// </summary>
        /// <param name="dto"></param>
        public virtual bool Delete(TDto dto)
        {
            return Delete(_mapper.Map<TDto, TEntity>(dto));
        }

        /// <summary>
        /// Remove uma lista de entidades por uma lista de DTOs
        /// </summary>
        /// <param name="list"></param>
        public virtual bool Delete(IList<TDto> list)
        {
            return Delete(_mapper.Map<IList<TDto>, IList<TEntity>>(list));
        }

        /// <summary>
        /// Desacopla a entidade do contexto por meio da DTO
        /// </summary>
        /// <param name="dto"></param>
        public virtual void DetachEntity(TDto dto)
        {
            DetachEntity(_mapper.Map<TDto, TEntity>(dto));
        }

        /// <summary>
        /// Retorna uma entidade convertida em DTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TDto> GetDtoAsync(int id)
        {
            return _mapper.Map<TEntity, TDto>(await GetEntityAsync(id));
        }

        /// <summary>
        /// Retorna uma entidade convertida em DTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TDto> GetDtoAsync(long id)
        {
            return _mapper.Map<TEntity, TDto>(await GetEntityAsync(id));
        }

        /// <summary>
        /// Retorna uma lista de DTOs
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IList<TDto>> ListDtoAsync()
        {
            return _mapper.Map<IList<TEntity>, IList<TDto>>(await ListEntityAsync());
        }

        /// <summary>
        /// Retorna uma lista de DTOs
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TDto> ListDto()
        {
            return _mapper.Map<IQueryable<TEntity>, IQueryable<TDto>>(ListEntity());
        }

        /// <summary>
        /// Atualiza uma lista de entidades por uma lista de DTOs
        /// </summary>
        /// <param name="list"></param>
        public virtual bool Update(IList<TDto> list)
        {
            return Update(_mapper.Map<IList<TDto>, IList<TEntity>>(list));
        }

        /// <summary>
        /// Atualiza uma entidade por uma DTO
        /// </summary>
        /// <param name="dto"></param>
        public virtual bool Update(TDto dto)
        {
            return Update(_mapper.Map<TDto, TEntity>(dto));
        }

        /// <summary>
        /// Atualiza uma entidade por uma DTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TDto dto)
        {
            return await UpdateAsync(_mapper.Map<TDto, TEntity>(dto));
        }

        #endregion 
    }
}