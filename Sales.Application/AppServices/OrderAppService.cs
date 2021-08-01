using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Application.AppServices
{
    public class OrderAppService: AppServiceBase<OrderViewModel>, IOrderAppService
    {
        private readonly IOrderService _orderService;

        public OrderAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IOrderService orderService): base (orderService, unitOfWork, mapper)
        {
            _orderService = orderService;
        }

        public async Task<IList<OrderReceiptViewModel>> GetReceipt(int id) => await _orderService.GetReceipt(id);
    }
}
