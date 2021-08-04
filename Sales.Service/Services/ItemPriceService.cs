using AutoMapper;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Model.Repositories.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;

namespace Sales.Service.Services
{
    public class ItemPriceService: EntityServiceBase<ItemPrice, ItemPriceViewModel>, IItemPriceService
    {
        private readonly IItemPriceRepository _itemPriceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemPriceService (
            IMapper mapper,
            IItemPriceRepository itemPriceRepository,
            IUnitOfWork unitOfWork) :
            base(
                mapper,
                itemPriceRepository,
                unitOfWork)
        {
            _itemPriceRepository = itemPriceRepository;
            _unitOfWork = unitOfWork;
        }

        public override PagedViewModel<ItemPriceViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
