using Sales.Model.Models.Interfaces.Base;
using System;

namespace Sales.Model.Dto
{
    public partial class ItemPriceDto: IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ItemDto Item { get; set; }
    }
}
