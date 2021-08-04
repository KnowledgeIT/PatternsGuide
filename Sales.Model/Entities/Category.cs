using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoryTax = new HashSet<CategoryTax>();
            ItemCategory = new HashSet<ItemCategory>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public bool Imported { get; set; }

        public virtual ICollection<CategoryTax> CategoryTax { get; set; }
        public virtual ICollection<ItemCategory> ItemCategory { get; set; }
    }
}
