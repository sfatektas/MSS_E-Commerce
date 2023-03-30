using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class ProductComment : BaseEntity
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierProductId { get; set; }
        public string Content { get; set; }
        public int  Point { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
