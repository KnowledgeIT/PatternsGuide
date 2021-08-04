using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class OrderItem
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

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
