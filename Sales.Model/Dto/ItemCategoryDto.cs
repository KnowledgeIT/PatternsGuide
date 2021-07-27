using Sales.Model.Models.Interfaces.Base;
using System;

namespace Sales.Model.Dto
{
    public partial class ItemCategoryDto: IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryDto Category { get; set; }
        public virtual ItemDto Item { get; set; }
    }
}
