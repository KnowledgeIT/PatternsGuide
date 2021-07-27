using Sales.Model.Models.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Sales.Model.Dto
{
    public partial class TaxDto: IBaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Imports { get; set; }

        public virtual ICollection<CategoryTaxDto> CategoryTax { get; set; }
    }
}
