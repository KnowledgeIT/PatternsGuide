using Sales.Model.Models.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Sales.Model.Dto
{
    public partial class ItemDto: IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<ItemCategoryDto> ItemCategory { get; set; }
        public virtual ICollection<ItemPriceDto> ItemPrice { get; set; }
        public virtual ICollection<OrderItemDto> OrderItem { get; set; }
    }
}
