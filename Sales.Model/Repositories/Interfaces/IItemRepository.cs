using Sales.Model.Entities;
using Sales.Model.Repositories.Base.Interfaces;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Interfaces
{
    public interface IItemRepository : IEntityRepositoryBase<Item>
    {
        ValueTask<bool> IsImported(int itemId);
    }
}
