using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class CategoryTax
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public int TaxId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
