using Sales.AppServices.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Application.AppServices.Interfaces
{
    public interface IItemCategoryAppService: 
        IAppServiceBase<ItemCategoryViewModel>
    {
        IList<ItemCategoryViewModel> List();
    }
}