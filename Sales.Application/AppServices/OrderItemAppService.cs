using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;

namespace Sales.Application.AppServices
{
    public class OrderItemAppService: AppServiceBase<OrderItemViewModel>, IOrderItemAppService
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IOrderItemService orderItemService): base (orderItemService, unitOfWork, mapper)
        {
            _orderItemService = orderItemService;
        }
    }
}
