using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BrandDtos
{
    public record BrandListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        public string ImageUrl { get; init; }
        public List<ProductListDto> Products { get; set; }

    }
}
