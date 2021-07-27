using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Item
    {
        public Item()
        {
            ItemCategory = new HashSet<ItemCategory>();
            ItemPrice = new HashSet<ItemPrice>();
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(512)]
        public string Description { get; set; }
        [Required]
        public bool? Available { get; set; }

        [InverseProperty("Item")]
        public virtual ICollection<ItemCategory> ItemCategory { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemPrice> ItemPrice { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
