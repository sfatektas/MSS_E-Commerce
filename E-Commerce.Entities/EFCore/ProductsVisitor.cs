using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductsVisitor : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SupplierProductId{ get; set; }
        public SupplierProduct SupplierProducts { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
