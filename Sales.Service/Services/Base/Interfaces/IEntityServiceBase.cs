using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services.Base.Interfaces
{
    public interface IEntityServiceBase<TEntity, TDto, TViewModel>:
        IViewModelServiceBase<TViewModel>
        where TEntity : class 
        where TDto : class
        where TViewModel : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IList<TEntity>> AddAsync(IList<TEntity> entities);
        bool Delete(TEntity entity);
        bool Delete(IList<TEntity> entity);
        void DetachEntity(TEntity entity);
        Task<TEntity> GetEntityAsync(int id);
        Task<TEntity> GetEntityAsync(long id);
        Task<IList<TEntity>> ListEntityAsync();
        bool Update(IList<TEntity> entities);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);

        Task<TDto> AddAsync(TDto dto);
        Task<IList<TDto>> AddAsync(IList<TDto> dtos);
        bool Delete(TDto dto);
        bool Delete(IList<TDto> dtos);
        void DetachEntity(TDto dto);
        Task<TDto> GetDtoAsync(int id);
        Task<TDto> GetDtoAsync(long id);
        Task<IList<TDto>> ListDtoAsync();
        bool Update(IList<TDto> dtos);
        bool Update(TDto dto);
        Task<bool> UpdateAsync(TDto dto);
    }
}
