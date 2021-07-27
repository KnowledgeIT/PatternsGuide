using Sales.Service.ViewModels.Internal.Base.Interfaces;
using System;
using System.Collections.Generic;

namespace Sales.Service.ViewModels.Internal
{
    public partial class OrderViewModel: IBaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual ICollection<OrderItemViewModel> OrderItem { get; set; }
    }
}
