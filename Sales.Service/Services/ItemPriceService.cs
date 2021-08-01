using AutoMapper;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;

namespace Sales.Service.Services
{
    public class ItemPriceService: EntityServiceBase<ItemPrice, ItemPriceDto, ItemPriceViewModel>, IItemPriceService
    {
        private readonly IItemPriceRepository _itemPriceRepository;

        public ItemPriceService (
            IMapper mapper,
            IItemPriceRepository itemPriceRepository) :
            base(
                mapper,
                itemPriceRepository)
        {
            _itemPriceRepository = itemPriceRepository;
        }

        public override PagedViewModel<ItemPriceViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
