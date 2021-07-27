using Sales.Application.AppServices.Interfaces;
using Sales.Service.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Controllers.Base;

namespace Sales.Controllers
{
    [Route("api/categories")]
    public class CategoryController: BaseController<CategoryViewModel>
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(
            ICategoryAppService categoryAppService,
            ILogger<CategoryController> logger) : base(categoryAppService, logger)
        {
            _categoryAppService = categoryAppService;
        }

    }
}
