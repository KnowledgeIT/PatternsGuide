using Newtonsoft.Json;
using System;

namespace Sales.Service.ViewModels.Internal
{
    public class OrderReceiptViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        [JsonProperty(PropertyName = "productName")]
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalesTaxes { get; set; }
        [JsonProperty(PropertyName = "total")]
        public decimal TotalPrice { get; set; }
    }
}
