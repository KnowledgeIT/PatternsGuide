using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class ItemCategory
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("ItemCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ItemCategory")]
        public virtual Item Item { get; set; }
    }
}
