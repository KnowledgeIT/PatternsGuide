using Sales.Application.AppServices.Interfaces;
using Sales.Service.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Controllers.Base;

namespace Sales.Controllers
{
    [Route("api/taxes")]
    public class TaxController: BaseController<TaxViewModel>
    {
        private readonly ITaxAppService _taxAppService;

        public TaxController(
            ITaxAppService taxAppService,
            ILogger<TaxController> logger) : base(taxAppService, logger)
        {
            _taxAppService = taxAppService;
        }
    }
}
