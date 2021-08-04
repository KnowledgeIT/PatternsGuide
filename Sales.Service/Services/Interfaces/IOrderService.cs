using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services.Interfaces
{
    public interface IOrderService : IEntityServiceBase<Order, OrderViewModel>
    {
        Task<IList<OrderReceiptViewModel>> GetReceipt(int id);
    }
}