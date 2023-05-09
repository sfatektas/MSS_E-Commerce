using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsInStockDtos
{
    public class CustomPreviewProductInStockInBasketListDto
    {
        public int Id { get; set; } // front tarafında selimin isteği js map() için 
        public int SupplierProductId { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public string CustomProductTitle { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public SupplierPreview Supplier { get; set; }
        public string SizeName { get; set; }

    }
    public class SupplierPreview
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
