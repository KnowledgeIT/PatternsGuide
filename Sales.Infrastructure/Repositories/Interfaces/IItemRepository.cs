using Sales.Infrastructure.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories.Interfaces
{
    public interface IItemRepository : IEntityRepositoryBase<Item, ItemDto>
    {
        ValueTask<bool> IsImported(int itemId);
    }
}
