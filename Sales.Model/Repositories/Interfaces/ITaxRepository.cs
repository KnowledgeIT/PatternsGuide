using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Interfaces
{
    public interface ITaxRepository : IEntityRepositoryBase<Tax, TaxDto>
    {
        Task<IEnumerable<Tax>> ListByItem(int itemId, bool withImportedToo = false);
        ValueTask<decimal> GetTotalTaxesByItem(int itemId, bool sumImported = false);
    }
}
