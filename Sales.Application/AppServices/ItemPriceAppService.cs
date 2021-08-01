using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;

namespace Sales.Application.AppServices
{
    public class ItemPriceAppService: AppServiceBase<ItemPriceViewModel>, IItemPriceAppService
    {
        private readonly IItemPriceService _itemPriceService;

        public ItemPriceAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IItemPriceService itemPriceService): base (itemPriceService, unitOfWork, mapper)
        {
            _itemPriceService = itemPriceService;
        }
    }
}
