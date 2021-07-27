using Sales.Service.ViewModels.Internal.Base.Interfaces;
using System;

namespace Sales.Service.ViewModels.Internal
{
    public partial class OrderItemViewModel: IBaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ItemViewModel Item { get; set; }
        public virtual OrderViewModel Order { get; set; }
    }
}
