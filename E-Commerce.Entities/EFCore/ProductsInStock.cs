using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductsInStock : BaseEntity
    {
        public int SupplierProductId { get; set; }
        public SupplierProduct SupplierProduct { get; set; }
        public double UnitPrice{ get; set; }
        public double Amount { get; set; }
        public bool IsFavoriteProduct { get; set; } 
    }
}
