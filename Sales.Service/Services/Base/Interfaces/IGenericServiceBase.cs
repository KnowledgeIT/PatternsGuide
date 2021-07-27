using System.Collections.Generic;
using System.Threading.Tasks;

namespace DimensionTrip.Service.Services.Base.Interfaces
{
    public interface IGenericServiceBase
    {
        Task AddAsync<T>(T entity) where T : class;
        Task AddAsync<T>(IEnumerable<T> list);
        void Delete<T>(T entity) where T : class;
        void Delete<T>(IEnumerable<T> entity) where T : class;
        Task DeleteAsync<T>(int id) where T : class;
        T DetachEntity<T>(T entity) where T : class;
        Task<T> GetAsync<T>(int id) where T : class;
        Task<T> GetAsync<T>(long id) where T : class;
        Task<IEnumerable<T>> ListAsync<T>() where T : class;
        void Update<T>(IEnumerable<T> list);
        void Update<T>(T entity);
        Task UpdateAsync<T>(T entity);
    }
}
