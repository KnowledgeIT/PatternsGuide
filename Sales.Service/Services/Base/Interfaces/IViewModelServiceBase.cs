using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services.Base.Interfaces
{
    public interface IViewModelServiceBase<TViewModel> 
        where TViewModel : class
    {
        Task<TViewModel> AddAsync(TViewModel viewModel);
        Task<IList<TViewModel>> AddAsync(IList<TViewModel> viewModels);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(long id);
        bool Delete(TViewModel viewModel);
        bool Delete(IList<TViewModel> viewModels);
        void DetachEntity(TViewModel viewModel);
        Task<TViewModel> GetAsync(int id);
        Task<TViewModel> GetAsync(long id);
        Task<IList<TViewModel>> ListAsync();
        bool Update(IList<TViewModel> viewModels);
        bool Update(TViewModel viewModel);
        Task<bool> UpdateAsync(TViewModel viewModel);

        PagedViewModel<TViewModel> GetPagedList(int page, int pageSize);
        PagedViewModel<TViewModel> GetPagedList(int page, int pageSize, int searchId);
        PagedViewModel<TViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams);
    }
}
