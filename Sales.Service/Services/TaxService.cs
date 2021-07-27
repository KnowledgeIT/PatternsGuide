using AutoMapper;
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
    public class TaxService: EntityServiceBase<Tax, TaxDto, TaxViewModel>, ITaxService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxService (
            IMapper mapper,
            ITaxRepository taxRepository) :
            base(
                mapper,
                taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async ValueTask<decimal> GetTotalTaxesByItem(int itemId, bool sumImported = false) => await _taxRepository.GetTotalTaxesByItem(itemId, sumImported);

        public override PagedViewModel<TaxViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams)
        {
            throw new System.NotImplementedException();
        }
    }
}
