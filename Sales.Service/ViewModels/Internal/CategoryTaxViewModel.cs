using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Service.ViewModels.Internal
{
    public class CategoryTaxViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public int TaxId { get; set; }

        public virtual CategoryViewModel Category { get; set; }
        public virtual TaxViewModel Tax { get; set; }
    }
}
