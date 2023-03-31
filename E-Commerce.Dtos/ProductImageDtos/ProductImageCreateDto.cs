using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductImageDtos
{
    public record ProductImageCreateDto : ICreateDto
    {
        public int SupplierProductId { get; init; }
        public string ImageUrl { get; init; }
    }
}
