using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Base.Interfaces
{
    public interface IEntityRepositoryBase<TEntity, TDto> : IGenericRepositoryBase
        where TEntity : class
        where TDto : class
    {
        #region Entity

        Task<TEntity> AddAsync(TEntity entity);
        Task<IList<TEntity>> AddAsync(IList<TEntity> list);

        bool Delete(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(long id);
        bool Delete(IList<TEntity> entity);

        void DetachEntity(TEntity entity);

        Task<TEntity> GetEntityAsync(int id);
        Task<TEntity> GetEntityAsync(long id);
        Task<IList<TEntity>> ListEntityAsync();
        IQueryable<TEntity> ListEntity();

        bool Update(IList<TEntity> list);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);

        #endregion

        #region DTO

        Task<TDto> AddAsync(TDto dto);
        Task<IList<TDto>> AddAsync(IList<TDto> list);

        bool Delete(TDto dto);
        bool Delete(IList<TDto> entity);
        void DetachEntity(TDto dto);
        
        Task<TDto> GetDtoAsync(int id);
        Task<TDto> GetDtoAsync(long id);
        Task<IList<TDto>> ListDtoAsync();
        IQueryable<TDto> ListDto();
        
        bool Update(IList<TDto> list);
        bool Update(TDto dto);
        Task<bool> UpdateAsync(TDto dto);

        #endregion
    }
}