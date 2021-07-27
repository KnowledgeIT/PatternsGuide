using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Service.Services
{
    public class ItemCategoryService: EntityServiceBase<ItemCategory, ItemCategoryDto, ItemCategoryViewModel>, IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;

        public ItemCategoryService (
            IMapper mapper,
            IItemCategoryRepository itemCategoryRepository) :
            base(
                mapper,
                itemCategoryRepository)
        {
            _itemCategoryRepository = itemCategoryRepository;
        }

        /// <summary>
        /// Monta a lista de Cards com detalhes de nomes e fotos
        /// </summary>
        /// <returns></returns>
        public IList<ItemCategoryViewModel> List()
        {
            return _mapper.Map<IList<ItemCategoryDto>, IList<ItemCategoryViewModel>>(_itemCategoryRepository.List());
        }

        /// <summary>
        /// Returns a Paged List
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public override PagedViewModel<ItemCategoryViewModel> GetPagedList(int page, int pageSize)
        {
            return _mapper.Map<PagedList<ItemCategoryDto>, PagedViewModel<ItemCategoryViewModel>>(
                _itemCategoryRepository.GetPagedList(_itemCategoryRepository.ListQuery(), page, pageSize));
        }

        public override PagedViewModel<ItemCategoryViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
