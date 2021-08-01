using AutoMapper;
using Sales.CrossCutting.Extensions;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services
{
    public class TaxService: EntityServiceBase<Tax, TaxDto, TaxViewModel>, ITaxService
    {
        #region Fields

        private readonly IItemRepository _itemRepository;
        private readonly IItemPriceRepository _itemPriceRepository;
        private readonly ITaxRepository _taxRepository;

        #endregion

        #region Constructor

        public TaxService (
            IMapper mapper,
            IItemRepository itemRepository,
            IItemPriceRepository itemPriceRepository,
            ITaxRepository taxRepository) :
            base(
                mapper,
                taxRepository)
        {
            _itemRepository = itemRepository;
            _itemPriceRepository = itemPriceRepository;
            _taxRepository = taxRepository;
        }

        #endregion

        #region Methods

        public async ValueTask<decimal> GetTotalTaxesByItem(int itemId, bool sumImported = false) => await _taxRepository.GetTotalTaxesByItem(itemId, sumImported);

        public async Task<Order> Calculate(Order order)
        {
            foreach (OrderItem orderItem in order.OrderItem)
            {
                var isImported = await _itemRepository.IsImported(orderItem.ItemId);
                var taxes = await GetTotalTaxesByItem(orderItem.ItemId, isImported);
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

        public override PagedViewModel<TaxViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
