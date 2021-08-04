using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class ItemPrice
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Item Item { get; set; }
    }
}
