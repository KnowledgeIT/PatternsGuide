using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoryTax = new HashSet<CategoryTax>();
            ItemCategory = new HashSet<ItemCategory>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public bool Imported { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<CategoryTax> CategoryTax { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<ItemCategory> ItemCategory { get; set; }
    }
}
