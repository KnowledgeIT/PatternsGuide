using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Application.AppServices.Interfaces;
using Sales.Controllers.Base;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Controllers
{
    [Route("api/orders")]
    public class OrderController: BaseController<OrderViewModel>
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(
            IOrderAppService orderAppService,
            ILogger<OrderController> logger) : base(orderAppService, logger)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet("{id}/receipt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IList<OrderReceiptViewModel>> GetReceipt(int id) => await _orderAppService.GetReceipt(id);
    }
}
