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
    public class ItemService: EntityServiceBase<Item, ItemViewModel>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService (
            IMapper mapper,
            IItemRepository itemRepository,
            IUnitOfWork unitOfWork) :
            base(
                mapper,
                itemRepository,
                unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public override PagedViewModel<ItemViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
