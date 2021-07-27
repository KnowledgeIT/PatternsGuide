using Sales.Model.Models.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Sales.Model.Dto
{
    public partial class OrderDto: IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual ICollection<OrderItemDto> OrderItem { get; set; }
    }
}
