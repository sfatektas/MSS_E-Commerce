using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.SizeDtos;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductDtos
{
    public class AdminProductViewModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public AdminBrandListModel BrandListDto { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int SizeTypeId { get; set; }
        public SizeListDto SizeListDto { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public List<SupplierProductListDto> SupplierProducts { get; set; }

    }
}
