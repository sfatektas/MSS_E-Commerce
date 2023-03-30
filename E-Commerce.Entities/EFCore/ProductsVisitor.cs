using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductsVisitor : BaseEntity
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Entities.EFCore.Identities.Customer Customer { get; set; }
        public int SupplierProductId{ get; set; }
        public SupplierProduct SupplierProducts { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
