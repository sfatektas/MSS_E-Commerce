using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductDtos
{
    public record ProductCreateDto : ICreateDto
    {
        public int BrandId { get; init; }
        public string Name { get; init; }
        public string Detail { get; init; }
        public int SizeTypeId { get; init; }
        public int CategoryId { get; init; }
        public string ImageUrl { get; set; }
    }
}
