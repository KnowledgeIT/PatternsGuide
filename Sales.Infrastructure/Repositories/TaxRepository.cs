using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;
using Sales.Model.UoW.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class TaxRepository : EntityRepositoryBase<Tax, TaxDto>, ITaxRepository
    {
        public TaxRepository(Context context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, mapper, unitOfWork)
        {

        }

        public async Task<IEnumerable<Tax>> ListByItem(int itemId, bool withImportedToo = false)
        {
            var result = await (from t in _context.Tax
                          join ct in _context.CategoryTax on t.Id equals ct.TaxId
                          join c in _context.Category on ct.CategoryId equals c.Id
                          join it in _context.ItemCategory on c.Id equals it.CategoryId
                          where it.ItemId == itemId && (c.Imported == false || c.Imported == withImportedToo)
                                select t)
                          .AsNoTracking()
                          .ToListAsync();

            return result;                            
        }

        public async ValueTask<decimal> GetTotalTaxesByItem(int itemId, bool sumImported = false)
        {
            return await (from t in _context.Tax
                                join ct in _context.CategoryTax on t.Id equals ct.TaxId
                                join c in _context.Category on ct.CategoryId equals c.Id
                                join it in _context.ItemCategory on c.Id equals it.CategoryId
                                where it.ItemId == itemId && (c.Imported == false || c.Imported == sumImported)
                                select t)
                                .SumAsync(s => s.Value);
        }
    }
}
