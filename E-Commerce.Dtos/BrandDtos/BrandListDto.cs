using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BrandDtos
{
    public class BrandListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        public string ImageUrl { get; init; }

        //[JsonIgnore]
        //public List<ProductListDto> Products { get; init; }

    }
}
