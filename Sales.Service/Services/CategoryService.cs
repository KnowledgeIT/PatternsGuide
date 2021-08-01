using AutoMapper;
using Sales.Model.Repositories.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services
{
    public class CategoryService: EntityServiceBase<Category, CategoryDto, CategoryViewModel>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService (
            IMapper mapper,
            ICategoryRepository categoryRepository) :
            base(
                mapper,
                categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override PagedViewModel<CategoryViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
