using Sales.Service.ViewModels.Internal.Base.Interfaces;
using System;
using System.Collections.Generic;

namespace Sales.Service.ViewModels.Internal
{
    public partial class CategoryViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public bool Imported { get; set; }

        public virtual ICollection<CategoryTaxViewModel> CategoryTax { get; set; }
        public virtual ICollection<ItemCategoryViewModel> ItemCategory { get; set; }
    }
}
