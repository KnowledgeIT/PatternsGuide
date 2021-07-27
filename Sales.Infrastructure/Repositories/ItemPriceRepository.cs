using AutoMapper;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Sales.Infrastructure.Repositories
{
    public class ItemPriceRepository : EntityRepositoryBase<ItemPrice, ItemPriceDto>, IItemPriceRepository
    {
        public ItemPriceRepository(Context context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, mapper, unitOfWork)
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
