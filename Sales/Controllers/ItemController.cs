using Sales.Application.AppServices.Interfaces;
using Sales.Service.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Controllers.Base;

namespace Sales.Controllers
{
    [Route("api/items")]
    public class ItemController: BaseController<ItemViewModel>
    {
        private readonly IItemAppService _itemAppService;

        public ItemController(
            IItemAppService itemAppService,
            ILogger<ItemController> logger) : base(itemAppService, logger)
        {
            _itemAppService = itemAppService;
        }
    }
}
