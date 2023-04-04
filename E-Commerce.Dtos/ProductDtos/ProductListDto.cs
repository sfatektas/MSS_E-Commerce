using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductDtos
{
    public record ProductListDto : IListDto
    {
        public int Id { get; init; }
        public int BrandId { get; init; }
        public string Name { get; init; }
        public string Detail { get; init; }
        public int SizeTypeId { get; init; }
        public int CategoryId { get; init; }
        public string ImageUrl { get; init; }
        public List<SupplierProductListDto> SupplierProducts { get; init; }

    }
}
