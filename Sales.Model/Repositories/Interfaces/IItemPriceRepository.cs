using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Interfaces
{
    public interface IItemPriceRepository : IEntityRepositoryBase<ItemPrice, ItemPriceDto>
    {
        ValueTask<decimal> GetPrice(int itemId);
    }
}
