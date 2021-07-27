using Sales.Service.ViewModels.Internal.Base.Interfaces;
using System;
using System.Collections.Generic;

namespace Sales.Service.ViewModels.Internal
{
    public partial class ItemViewModel: IBaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<ItemCategoryViewModel> ItemCategory { get; set; }
        public virtual ICollection<ItemPriceViewModel> ItemPrice { get; set; }
        public virtual ICollection<OrderItemViewModel> OrderItem { get; set; }
    }
}
