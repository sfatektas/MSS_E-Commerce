using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class SupplierAddingProduct : BaseEntity
    {
        public int SupplierProductId { get;set; }
        public SupplierProduct SupplierProducts { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
