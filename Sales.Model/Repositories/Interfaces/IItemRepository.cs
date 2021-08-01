using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Interfaces
{
    public interface IItemRepository : IEntityRepositoryBase<Item, ItemDto>
    {
        ValueTask<bool> IsImported(int itemId);
    }
}
