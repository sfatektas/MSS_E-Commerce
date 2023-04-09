using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BrandDtos
{
    public record BrandCreateDto : ICreateDto
    {
        public string Defination { get; init; }
        public string ImageUrl { get; set; }
    }
}
