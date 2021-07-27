using Sales.CrossCutting.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories.Base.Interfaces
{
    public interface IGenericRepositoryBase
    {
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<IList<T>> AddAsync<T>(IList<T> list);
        
        bool Delete<T>(T entity) where T : class;
        bool Delete<T>(IList<T> entity) where T : class;
        Task<bool> DeleteAsync<T>(int id) where T : class;

        void DetachEntity<T>(T entity) where T : class;
        
        Task<T> GetAsync<T>(int id) where T : class;
        Task<T> GetAsync<T>(long id) where T : class;
        Task<IList<T>> ListAsync<T>() where T : class;
        IQueryable<T> List<T>() where T : class;
        
        bool Update<T>(IList<T> list);
        bool Update<T>(T entity);
        Task<bool> UpdateAsync<T>(T entity);

        PagedList<T> GetPagedList<T>(int page, int pageSize) where T : class;
        PagedList<T> GetPagedList<T>(IQueryable<T> query, int page, int pageSize) where T : class;
    }
}