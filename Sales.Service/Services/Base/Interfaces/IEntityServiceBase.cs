using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services.Base.Interfaces
{
    public interface IEntityServiceBase<TEntity, TViewModel>:
        IViewModelServiceBase<TViewModel>
        where TEntity : class 
        where TViewModel : class
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IList<TEntity> entities);
        bool Delete(TEntity entity);
        bool Delete(IList<TEntity> entity);
        void DetachEntity(TEntity entity);
        Task<TEntity> GetEntityAsync(int id);
        Task<TEntity> GetEntityAsync(long id);
        Task<IList<TEntity>> ListEntityAsync();
        bool Update(IList<TEntity> entities);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
    }
}
