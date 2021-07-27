using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompletedAt { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NetPrice { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalTaxes { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("OrderItem")]
        public virtual Item Item { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderItem")]
        public virtual Order Order { get; set; }
    }
}
