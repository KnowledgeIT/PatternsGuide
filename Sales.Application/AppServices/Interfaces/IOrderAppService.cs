using Sales.AppServices.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Application.AppServices.Interfaces
{
    public interface IOrderAppService : IAppServiceBase<OrderViewModel>
    {
        Task<IList<OrderReceiptViewModel>> GetReceipt(int id);
    }
}