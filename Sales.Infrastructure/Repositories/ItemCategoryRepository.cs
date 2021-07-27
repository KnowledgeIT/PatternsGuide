using AutoMapper;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Infrastructure.Repositories
{
    public class ItemCategoryRepository: EntityRepositoryBase<ItemCategory, ItemCategoryDto>, IItemCategoryRepository
    {
        public ItemCategoryRepository(Context context, IMapper mapper, IUnitOfWork unitOfWork): base (context, mapper, unitOfWork)
        {

        }

        /// <summary>
        /// Monta a lista de Cards com detalhes de nomes e fotos
        /// </summary>
        /// <returns></returns>
        public IQueryable<ItemCategoryDto> ListQuery()
        {
            return (from c in _context.ItemCategory
                          select new ItemCategoryDto
                          {
                              
                          })
                          .AsNoTracking()
                          .AsQueryable();
        }

        /// <summary>
        /// Monta a lista de Cards com detalhes de nomes e fotos
        /// </summary>
        /// <returns></returns>
        public IList<ItemCategoryDto> List()
        {
            return ListQuery().ToList();
        }
    }
}
