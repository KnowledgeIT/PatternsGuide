using Sales.Model.Models.Interfaces.Base;
using System;

namespace Sales.Model.Dto
{
    public partial class OrderReceiptDto : IBaseDto
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SalesTaxes { get; set; }
    }
}
