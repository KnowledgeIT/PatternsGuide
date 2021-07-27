using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.AppServices.Base.Interfaces;
using Sales.CrossCutting.Helpers;
using Sales.Service.ViewModels.Internal.Base.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Sales.Controllers.Base
{
    [ApiController]
    public abstract class BaseController<TViewModel>: ControllerBase where TViewModel : class, IBaseViewModel
    {
        #region Fields

        protected readonly ILogger _logger;
        protected readonly IAppServiceBase<TViewModel> _appServiceBase;

        #endregion

        #region Constructor

        public BaseController(
            IAppServiceBase<TViewModel> appServiceBase,
            ILogger<BaseController<TViewModel>> logger)
        {
            _appServiceBase = appServiceBase;
            _logger = logger;
        }

        #endregion

        #region GET

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IList<TViewModel>> ListAsync()
        {
            return await _appServiceBase.ListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<TViewModel> GetAsync(int id)
        {
            return await _appServiceBase.GetAsync(id);
        }

        [HttpGet("{page}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual PagedList<TViewModel> GetPagedList(int page, int pageSize)
        {
            return _appServiceBase.GetPagedList(page, pageSize);
        }

        [HttpGet("{page}/{pageSize}/{searchId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual PagedList<TViewModel> GetPagedList(int searchId, int page, int pageSize)
        {
            return _appServiceBase.GetPagedList(page, pageSize, searchId);
        }

        #endregion

        #region Updates

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> PostAsync([FromBody] TViewModel value)
        {   
            var result = await _appServiceBase.AddAsync(value);

            if (result != null)
            {
                IBaseViewModel viewModel = result;
                return new ObjectResult(viewModel) { StatusCode = StatusCodes.Status201Created };
            }
            else
                return StatusCode((int)HttpStatusCode.Conflict);
        }

        [HttpPost("bulkcreate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> PostAsync([FromBody] IList<TViewModel> value)
        {
            var result = await _appServiceBase.AddAsync(value);

            if (result != null)
            {
                IList<TViewModel> viewModel = result;
                return new ObjectResult(viewModel) { StatusCode = StatusCodes.Status201Created };
            }
            else
                return StatusCode((int)HttpStatusCode.Conflict);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> PutAsync([FromBody] TViewModel value)
        {
            return 
                await _appServiceBase.UpdateAsync(value) == true ? 
                    StatusCode((int)HttpStatusCode.NoContent) : StatusCode((int)HttpStatusCode.Conflict);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> PutAsync([Required]int id, [FromBody] TViewModel value)
        {
            return
                await _appServiceBase.UpdateAsync(value) == true ?
                    StatusCode((int)HttpStatusCode.NoContent) : StatusCode((int)HttpStatusCode.Conflict);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> DeleteAsync([Required]int id)
        {
            return 
                await _appServiceBase.DeleteAsync(id) == true ?
                    StatusCode((int)HttpStatusCode.NoContent) : StatusCode((int)HttpStatusCode.Conflict);
        }

        #endregion
    }
}
