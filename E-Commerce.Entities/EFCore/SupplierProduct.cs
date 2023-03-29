using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class SupplierProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public double UnitPrice { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public string CustomProductTitle { get; set; }
        public string CustomProductDefination { get; set; }
        public int VisitCounter { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
