using Sales.Service.ViewModels.Internal.Base.Interfaces;
using System;

namespace Sales.Service.ViewModels.Internal
{
    public partial class ItemPriceViewModel: IBaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ItemViewModel Item { get; set; }
    }
}
