using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.CategoryDtos;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsInStockDtos
{
    public class CustomPreviewProductInStockListDto
    {
        public int Id { get; set; }
        public int SupplierProductId { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }

        public string ProductTitle { get; set; }

        public CategoryListDto Category { get; set; }

        public BrandListDto Brand { get; set; }

        public double UnitPrice { get; set; }

    }
}
