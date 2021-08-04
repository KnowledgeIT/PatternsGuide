using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
