using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Model.Repositories.Interfaces
{
    public interface IOrderRepository : IEntityRepositoryBase<Order, OrderDto>
    {
        Task<IEnumerable<OrderReceiptDto>> GetReceipt(int Id);
    }
}
