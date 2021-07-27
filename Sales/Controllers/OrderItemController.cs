using Sales.Application.AppServices.Interfaces;
using Sales.Service.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Controllers.Base;

namespace Sales.Controllers
{
    [Route("api/orderitems")]
    public class OrderItemController: BaseController<OrderItemViewModel>
    {
        private readonly IOrderItemAppService _orderItemAppService;

        public OrderItemController(
            IOrderItemAppService orderItemAppService,
            ILogger<OrderItemController> logger) : base(orderItemAppService, logger)
        {
            _orderItemAppService = orderItemAppService;
        }
    }
}
