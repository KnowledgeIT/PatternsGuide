using AutoMapper;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;

namespace Sales.Service.Services
{
    public class OrderItemService: EntityServiceBase<OrderItem, OrderItemDto, OrderItemViewModel>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService (
            IMapper mapper,
            IOrderItemRepository orderItemRepository) :
            base(
                mapper,
                orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public override PagedViewModel<OrderItemViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
