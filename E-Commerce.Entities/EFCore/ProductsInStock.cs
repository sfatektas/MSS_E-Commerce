using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductsInStock : BaseEntity
    {
        public int SupplierProductsId { get; set; }
        public SupplierProduct SupplierProducts { get; set; }
        public double UnitPrice{ get; set; }
        public double Amount { get; set; }
    }
}
