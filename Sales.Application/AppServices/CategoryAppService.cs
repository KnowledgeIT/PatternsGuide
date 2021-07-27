using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;

namespace Sales.Application.AppServices
{
    public class CategoryAppService: AppServiceBase<CategoryViewModel>, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            ICategoryService categoryService): base (categoryService, unitOfWork, mapper)
        {
            _categoryService = categoryService;
        }
    }
}
