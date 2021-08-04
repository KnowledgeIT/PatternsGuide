using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Base.Interfaces
{
    public interface IEntityRepositoryBase<TEntity> : IGenericRepositoryBase
        where TEntity : class
    {
        #region Entity

        Task AddAsync(TEntity entity);
        Task AddAsync(IList<TEntity> list);

        void Delete(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(long id);
        void Delete(IList<TEntity> entity);

        void DetachEntity(TEntity entity);

        Task<TEntity> GetEntityAsync(int id);
        Task<TEntity> GetEntityAsync(long id);
        Task<IList<TEntity>> ListEntityAsync();
        IQueryable<TEntity> ListEntity();

        void Update(IList<TEntity> list);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        #endregion
    }
}