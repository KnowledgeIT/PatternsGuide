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
    public class ItemService: EntityServiceBase<Item, ItemDto, ItemViewModel>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService (
            IMapper mapper,
            IItemRepository itemRepository) :
            base(
                mapper,
                itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public override PagedViewModel<ItemViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
