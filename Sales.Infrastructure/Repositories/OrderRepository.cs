using AutoMapper;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories.Base;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Model.Dto;
using Sales.Model.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Sales.Infrastructure.Repositories
{
    public class OrderRepository : EntityRepositoryBase<Order, OrderDto>, IOrderRepository
    {
        public OrderRepository(Context context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, mapper, unitOfWork)
        {

        }

        public async Task<IEnumerable<OrderReceiptDto>> GetReceipt(int Id)
        {
            var result = await (from o in _context.Order
                          join oi in _context.OrderItem on o.Id equals oi.OrderId
                          join ip in _context.ItemPrice on oi.ItemId equals ip.ItemId
                          join i in _context.Item on ip.ItemId equals i.Id
                          where o.Id == Id
                          group new
                          {
                              o.Id,
                              o.CompletedAt,
                              o.CreatedAt,
                              i.Name,
                              oi.Quantity,
                              oi.TotalTaxes,
                              oi.TotalPrice,
                              ip.Price,
                              o.UpdatedAt
                          } by new
                          {
                              o.Id,
                              o.CompletedAt,
                              o.CreatedAt,
                              i.Name,
                              ip.Price,
                              o.UpdatedAt
                          } into r
                          select new OrderReceiptDto
                          {
                              Id = r.Key.Id,
                              CompletedAt = r.Key.CompletedAt,
                              CreatedAt = r.Key.CreatedAt,
                              ItemName = r.Key.Name,
                              Quantity = r.Sum(s => s.Quantity),
                              SalesTaxes = r.Sum(s => s.TotalTaxes),
                              TotalPrice = r.Sum(s => s.TotalPrice),
                              UnitPrice = r.Key.Price,
                              UpdatedAt = r.Key.UpdatedAt
                          }).ToListAsync();

            return result;
        }
    }
}
