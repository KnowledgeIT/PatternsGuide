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
using Sales.Model.UoW.Interfaces;

namespace Sales.Service.Services
{
    public class OrderService: EntityServiceBase<Order, OrderViewModel>, IOrderService
    {
        #region Fields

        private readonly IOrderRepository _orderRepository;
        private readonly ITaxService _taxService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public OrderService(
            IMapper mapper,
            IOrderRepository orderRepository,
            ITaxService taxService,
            IUnitOfWork unitOfWork) :
            base(
                mapper,
                orderRepository,
                unitOfWork)
        {
            _orderRepository = orderRepository;
            _taxService = taxService;
            _unitOfWork = unitOfWork;
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
