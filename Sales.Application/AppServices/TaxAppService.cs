using AutoMapper;
using Sales.Application.AppServices.Base;
using Sales.Application.AppServices.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Service.Services.Interfaces;
using Sales.Service.ViewModels.Internal;

namespace Sales.Application.AppServices
{
    public class TaxAppService: AppServiceBase<TaxViewModel>, ITaxAppService
    {
        private readonly ITaxService _taxService;

        public TaxAppService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            ITaxService taxService): base (taxService, unitOfWork, mapper)
        {
            _taxService = taxService;
        }
    }
}
