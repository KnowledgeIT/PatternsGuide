using Sales.Model.Models.Interfaces.Base;
using System;

namespace Sales.Model.Dto
{
    public partial class OrderItemDto: IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ItemDto Item { get; set; }
        public virtual OrderDto Order { get; set; }
    }
}
