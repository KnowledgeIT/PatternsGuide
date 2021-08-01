using AutoMapper;
using Sales.AppServices.Base.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Application.AppServices.Base
{
    public abstract class AppServiceBase<TViewModel>: 
        IAppServiceBase<TViewModel>
        where TViewModel : class
    {
        #region Fields

        protected readonly IViewModelServiceBase<TViewModel> _viewModelServiceBase;

        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public AppServiceBase(
            IViewModelServiceBase<TViewModel> viewModelServiceBase,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _viewModelServiceBase = viewModelServiceBase;

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new Entity
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> AddAsync(TViewModel viewModel)
        {
            return await _viewModelServiceBase.AddAsync(viewModel);
        }

        /// <summary>
        /// Adds new Entities from a List
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        public virtual async Task<IList<TViewModel>> AddAsync(IList<TViewModel> viewModels)
        {
            return await _viewModelServiceBase.AddAsync(viewModels);
        }

        /// <summary>
        /// Deletes or Removes an Entity
        /// </summary>
        /// <param name="id"></param>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _viewModelServiceBase.DeleteAsync(id);
        }

        /// <summary>
        /// Deletes or Removes Entities from a List
        /// </summary>
        /// <param name="viewModels"></param>
        public virtual bool Delete(IList<TViewModel> viewModels)
        {
            return _viewModelServiceBase.Delete(viewModels);
        }

        /// <summary>
        /// Returns one
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> GetAsync(int id)
        {
            return await _viewModelServiceBase.GetAsync(id);
        }

        /// <summary>
        /// Returns one
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> GetAsync(long id)
        {
            return await _viewModelServiceBase.GetAsync(id);
        }

        /// <summary>
        /// Returns a Paged List
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual PagedViewModel<TViewModel> GetPagedList(int page, int pageSize)
        {
            return _viewModelServiceBase.GetPagedList(page, pageSize);
        }

        /// <summary>
        /// Returns a Paged List conforme um parâmetro de busca
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchId"></param>
        /// <returns></returns>
        public virtual PagedViewModel<TViewModel> GetPagedList(int page, int pageSize, int searchId)
        {
            return _viewModelServiceBase.GetPagedList(page, pageSize, searchId);
        }

        /// <summary>
        /// Retorna uma lista de ViewModels
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IList<TViewModel>> ListAsync()
        {
            return await _viewModelServiceBase.ListAsync();
        }

        /// <summary>
        /// Atualiza uma lista de entidades por uma lista de ViewModels
        /// </summary>
        /// <param name="viewModels"></param>
        public virtual bool Update(IList<TViewModel> viewModels)
        {
            return _viewModelServiceBase.Update(viewModels);
        }

        /// <summary>
        /// Atualiza uma entidade por uma ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TViewModel viewModel)
        {
            return await _viewModelServiceBase.UpdateAsync(viewModel);
        }

        #endregion
    }
}
