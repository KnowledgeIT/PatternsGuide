using Sales.Infrastructure.Repositories.Base.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;

namespace Sales.Infrastructure.Repositories.Interfaces
{
    public interface IOrderItemRepository : IEntityRepositoryBase<OrderItem, OrderItemDto>
    {

    }
}
