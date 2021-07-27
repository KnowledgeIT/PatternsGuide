using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Application.AppServices
{
    public class ItemCategoryAppService: AppServiceBase<ItemCategoryViewModel>, IItemCategoryAppService
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IItemCategoryService itemCategoryService) : base(itemCategoryService, unitOfWork, mapper)
        {
            _itemCategoryService = itemCategoryService;
        }

        /// <summary>
        /// Monta a lista de Cards com detalhes de nomes e fotos
        /// </summary>
        /// <returns></returns>
        public IList<ItemCategoryViewModel> List()
        {
            return _itemCategoryService.List();
        }
    }
}
