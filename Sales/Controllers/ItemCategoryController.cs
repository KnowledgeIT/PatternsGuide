using Sales.Application.AppServices.Interfaces;
using Sales.Service.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Sales.Controllers.Base;

namespace Sales.Controllers
{
    [Route("api/itemcategories")]
    public class ItemCategoryController: BaseController<ItemCategoryViewModel>
    {
        private readonly IItemCategoryAppService _itemCategoryAppService;

        public ItemCategoryController(
            IItemCategoryAppService itemCategoryAppService,
            ILogger<ItemCategoryController> logger) : base(itemCategoryAppService, logger)
        {
            _itemCategoryAppService = itemCategoryAppService;
        }
    }
}
