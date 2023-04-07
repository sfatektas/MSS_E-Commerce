using E_Commerce.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BrandDtos
{
    public class AdminBrandListModel
    {
        public int Id { get; set; }
        public string Defination { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductListDto> Products { get; set; }
    }
}
