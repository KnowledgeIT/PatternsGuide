using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sales.Model.Entities
{
    public partial class CategoryTax
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public int TaxId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("CategoryTax")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(TaxId))]
        [InverseProperty("CategoryTax")]
        public virtual Tax Tax { get; set; }
    }
}
