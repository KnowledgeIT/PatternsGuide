using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class ItemPriceRepository : EntityRepositoryBase<ItemPrice>, IItemPriceRepository
    {
        public ItemPriceRepository(Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public async ValueTask<decimal> GetPrice(int itemId)
        {
            var result = await _context.ItemPrice
                          .Where(w => w.ItemId == itemId && 
                            ((w.StartDate != null ? 
                                w.StartDate >= DateTime.Now && w.EndDate <= DateTime.Now : 
                                w.StartDate == w.StartDate) == true))
                          .OrderByDescending(o => o.StartDate)
                          .Select(s => s.Price)
                          .FirstOrDefaultAsync();

            return result;
        }
    }
}
