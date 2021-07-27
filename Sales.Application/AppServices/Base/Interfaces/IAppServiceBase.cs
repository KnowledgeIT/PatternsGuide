using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.AppServices.Base.Interfaces
{
    public interface IAppServiceBase<TViewModel> 
        where TViewModel: class
    {
        Task<TViewModel> AddAsync(TViewModel viewModel);
        Task<IList<TViewModel>> AddAsync(IList<TViewModel> viewModels);
        Task<bool> DeleteAsync(int id);
        bool Delete(IList<TViewModel> viewModels);
        Task<TViewModel> GetAsync(int id);
        Task<TViewModel> GetAsync(long id);
        Task<IList<TViewModel>> ListAsync();
        bool Update (IList<TViewModel> viewModels);
        Task<bool> UpdateAsync(TViewModel viewModel);

        PagedViewModel<TViewModel> GetPagedList(int page, int pageSize);
        PagedViewModel<TViewModel> GetPagedList(int page, int pageSize, int searchId);
    }
}
