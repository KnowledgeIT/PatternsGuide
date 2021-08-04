using AutoMapper;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class CategoryRepository : EntityRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
