using Sales.Model.Entities;
using Sales.Model.Repositories.Base.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Interfaces
{
    public interface ITaxRepository : IEntityRepositoryBase<Tax>
    {
        Task<IEnumerable<Tax>> ListByItem(int itemId, bool withImportedToo = false);
        ValueTask<decimal> GetTotalTaxesByItem(int itemId, bool sumImported = false);
    }
}
