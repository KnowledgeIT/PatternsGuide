using AutoMapper;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;

namespace Sales.Infrastructure.Repositories
{
    public class OrderItemRepository : EntityRepositoryBase<OrderItem, OrderItemDto>, IOrderItemRepository
    {
        public OrderItemRepository(Context context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, mapper, unitOfWork)
        {

        }
    }
}
