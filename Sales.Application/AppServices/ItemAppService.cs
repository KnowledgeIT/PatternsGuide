using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;

namespace Sales.Application.AppServices
{
    public class ItemAppService: AppServiceBase<ItemViewModel>, IItemAppService
    {
        private readonly IItemService _itemService;

        public ItemAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IItemService itemService): base (itemService, unitOfWork, mapper)
        {
            _itemService = itemService;
        }
    }
}
