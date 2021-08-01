using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;
using Sales.Model.UoW.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class ItemRepository : EntityRepositoryBase<Item, ItemDto>, IItemRepository
    {
        public ItemRepository(Context context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, mapper, unitOfWork)
        {

        }

        public async ValueTask<bool> IsImported(int itemId)
        {
            return await (from i in _context.Item
                          join ic in _context.ItemCategory on i.Id equals ic.ItemId
                          join c in _context.Category on ic.CategoryId equals c.Id
                          where i.Id == itemId
                          select c.Imported)
                          .FirstOrDefaultAsync();

        }
    }
}
