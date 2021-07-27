using Sales.Infrastructure.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Infrastructure.Repositories.Interfaces
{
    public interface IItemCategoryRepository: IEntityRepositoryBase<ItemCategory, ItemCategoryDto>
    {
        IQueryable<ItemCategoryDto> ListQuery();
        IList<ItemCategoryDto> List();
    }
}
