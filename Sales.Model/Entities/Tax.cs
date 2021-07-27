using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class Tax
    {
        public Tax()
        {
            CategoryTax = new HashSet<CategoryTax>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Required]
        [StringLength(30)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Value { get; set; }
        public bool Imports { get; set; }

        [InverseProperty("Tax")]
        public virtual ICollection<CategoryTax> CategoryTax { get; set; }
    }
}
