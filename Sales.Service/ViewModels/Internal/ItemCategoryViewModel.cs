using Sales.Service.ViewModels.Internal.Base.Interfaces;
using Newtonsoft.Json;
using System;

namespace Sales.Service.ViewModels.Internal
{
    public partial class ItemCategoryViewModel: IBaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryViewModel Category { get; set; }
        public virtual ItemViewModel Item { get; set; }
    }
}
