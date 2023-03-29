using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductImage : BaseEntity
    {
        public int SupplierProductId { get; set; }
        public SupplierProduct SupplierProducts { get; set; }
        public string ImageUrl { get; set; }
    }
}
