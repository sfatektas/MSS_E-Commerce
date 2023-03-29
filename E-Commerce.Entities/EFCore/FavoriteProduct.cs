using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class FavoriteProduct : BaseEntity
    {
        public int SupplierProdcutsId { get; set; }
        public SupplierProduct SupplierProducts { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
