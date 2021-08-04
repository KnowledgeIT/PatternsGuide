using Sales.CrossCutting.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Base.Interfaces
{
    public interface IGenericRepositoryBase
    {
        Task AddAsync<T>(T entity) where T : class;
        Task AddAsync<T>(IList<T> list);
        
        void Delete<T>(T entity) where T : class;
        void Delete<T>(IList<T> entity) where T : class;
        Task DeleteAsync<T>(int id) where T : class;

        void DetachEntity<T>(T entity) where T : class;
        
        Task<T> GetAsync<T>(int id) where T : class;
        Task<T> GetAsync<T>(long id) where T : class;
        Task<IList<T>> ListAsync<T>() where T : class;
        IQueryable<T> List<T>() where T : class;
        
        void Update<T>(IList<T> list);
        void Update<T>(T entity);
        Task UpdateAsync<T>(T entity);

        PagedList<T> GetPagedList<T>(int page, int pageSize) where T : class;
        PagedList<T> GetPagedList<T>(IQueryable<T> query, int page, int pageSize) where T : class;
    }
}