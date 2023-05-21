using E_Commerce.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class SupplierProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Entities.EFCore.Identities.Supplier Supplier { get; set; }
        public double UnitPrice { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public string CustomProductTitle { get; set; }
        public string CustomProductDefination { get; set; }
        public int VisitCounter { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC);

        //Navigate Prop
        // Ürünün genel değerlendirme puanı

        public ProductsInStock ProductsInStock { get; set; }
        public List<PriceHistory> PriceHistories { get; set; }
        public List<SupplierAddingProduct> SupplierAddingProducts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductsVisitor> ProductsVisitors { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<FavoriteProduct> FavoriteProducts { get; set; }
    }
}
