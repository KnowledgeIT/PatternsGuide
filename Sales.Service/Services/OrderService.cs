using AutoMapper;
using Sales.CrossCutting.Extensions;
using Sales.Model.Repositories.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services
{
    public class OrderService: EntityServiceBase<Order, OrderDto, OrderViewModel>, IOrderService
    {
        #region Fields

        private readonly IItemRepository _itemRepository;
        private readonly IItemPriceRepository _itemPriceRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITaxRepository _taxRepository;

        #endregion

        #region Constructor

        public OrderService(
            IMapper mapper,
            IItemRepository itemRepository,
            IItemPriceRepository itemPriceRepository,
            IOrderRepository orderRepository,
            ITaxRepository taxRepository) :
            base(
                mapper,
                orderRepository)
        {
            _itemRepository = itemRepository;
            _itemPriceRepository = itemPriceRepository;
            _orderRepository = orderRepository;
            _taxRepository = taxRepository;
        }

        #endregion

        #region Methods

        public async Task<IList<OrderReceiptViewModel>> GetReceipt(int id) =>
            _mapper.Map<IEnumerable<OrderReceiptDto>, IList<OrderReceiptViewModel>>(
                await _orderRepository.GetReceipt(id));

        public async override Task<IList<OrderViewModel>> AddAsync(IList<OrderViewModel> viewModel)
        {
            var orders = _mapper.Map<IList<OrderViewModel>, IList<Order>>(viewModel);

            foreach(Order order in orders)
            {
                await Calculate(order);
            }

            return await base.AddAsync(_mapper.Map<IList<Order>, IList<OrderViewModel>>(orders));
        }

        public async override Task<OrderViewModel> AddAsync(OrderViewModel viewModel)
        {
            var order = _mapper.Map<OrderViewModel, Order>(viewModel);

            await Calculate(order);
            
            return await base.AddAsync(_mapper.Map<Order, OrderViewModel>(order));
        }

        public override PagedViewModel<OrderViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Local methods

        protected async Task<Order> Calculate(Order order)
        {
            foreach (OrderItem orderItem in order.OrderItem)
            {
                var isImported = await _itemRepository.IsImported(orderItem.ItemId);
                var taxes = await _taxRepository.GetTotalTaxesByItem(orderItem.ItemId, isImported);
                var netPrice = await _itemPriceRepository.GetPrice(orderItem.ItemId);

                if (orderItem.NetPrice == 0)
                    orderItem.NetPrice = netPrice * orderItem.Quantity;
                else
                    orderItem.NetPrice *= orderItem.Quantity;

                orderItem.TotalTaxes = 
                    taxes > 0 ? Math.Round(orderItem.NetPrice * (taxes / 100), 2).RoundCentsUp() : 0;
                
                orderItem.TotalPrice = Math.Round(orderItem.NetPrice + orderItem.TotalTaxes, 2);
            }

            return order;
        }

        #endregion
    }
}
