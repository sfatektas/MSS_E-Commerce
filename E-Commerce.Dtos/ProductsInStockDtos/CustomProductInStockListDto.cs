using E_Commerce.Dtos.ColorDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.ProductCommentDtos;
using E_Commerce.Dtos.SizeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsInStockDtos
{
    public class CustomProductInStockListDto
    {
        public List<DifferentSizeAvaibleProductListDto> AvaiableSizes { get; set; }
        public List<DifferentColorAvaibleProductListDto> AvaiableColors { get; set; }
        public ProductInStockListDto ProductInStock { get; set; }
        public List<ProductInStockListDto> SupplierProductsFromOtherSupplier { get; set; }

    }
    public class DifferentSizeAvaibleProductListDto
    {
        public int SupplierProductId { get; set; }
        public SizeListDto Size { get; set; }
    }
    public class DifferentColorAvaibleProductListDto
    {
        public int SupplierProductId { get; set; }
        public ColorListDto Color { get; set; }
    }
}
