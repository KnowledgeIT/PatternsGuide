using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Model.Dto
{
    public class CategoryTaxDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public int TaxId { get; set; }

        public virtual CategoryDto Category { get; set; }
        public virtual TaxDto Tax { get; set; }
    }
}
