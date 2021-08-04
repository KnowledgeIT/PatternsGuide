using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Tax
    {
        public Tax()
        {
            CategoryTax = new HashSet<CategoryTax>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Imports { get; set; }

        public virtual ICollection<CategoryTax> CategoryTax { get; set; }
    }
}
