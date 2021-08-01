using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;

namespace Sales.Model.Repositories.Interfaces
{
    public interface ICategoryRepository : IEntityRepositoryBase<Category, CategoryDto>
    {

    }
}
