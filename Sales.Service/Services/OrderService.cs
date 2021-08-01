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

        private readonly IOrderRepository _orderRepository;
        private readonly ITaxService _taxService;

        #endregion

        #region Constructor

        public OrderService(
            IMapper mapper,
            IOrderRepository orderRepository,
            ITaxService taxService) :
            base(
                mapper,
                orderRepository)
        {
            _orderRepository = orderRepository;
            _taxService = taxService;
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
                await _taxService.Calculate(order);
            }

            return await base.AddAsync(_mapper.Map<IList<Order>, IList<OrderViewModel>>(orders));
        }

        public async override Task<OrderViewModel> AddAsync(OrderViewModel viewModel)
        {
            var order = _mapper.Map<OrderViewModel, Order>(viewModel);

            await _taxService.Calculate(order);

            return await base.AddAsync(_mapper.Map<Order, OrderViewModel>(order));
        }

        public override PagedViewModel<OrderViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
