using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Item
    {
        public Item()
        {
            ItemCategory = new HashSet<ItemCategory>();
            ItemPrice = new HashSet<ItemPrice>();
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<ItemCategory> ItemCategory { get; set; }
        public virtual ICollection<ItemPrice> ItemPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
