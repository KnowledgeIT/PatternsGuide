using Sales.Model.Models.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Sales.Model.Dto
{
    public partial class CategoryDto : IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public bool Imported { get; set; }

        public virtual ICollection<CategoryTaxDto> CategoryTax { get; set; }
        public virtual ICollection<ItemCategoryDto> ItemCategory { get; set; }
    }
}
