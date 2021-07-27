using Sales.Application.AppServices.Interfaces;
using Sales.Service.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Controllers.Base;

namespace Sales.Controllers
{
    [Route("api/itemprices")]
    public class ItemPriceController: BaseController<ItemPriceViewModel>
    {
        private readonly IItemPriceAppService _itemPriceAppService;

        public ItemPriceController(
            IItemPriceAppService itemPriceAppService,
            ILogger<ItemPriceController> logger) : base(itemPriceAppService, logger)
        {
            _itemPriceAppService = itemPriceAppService;
        }
    }
}
