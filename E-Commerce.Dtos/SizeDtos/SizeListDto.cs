using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SizeDtos
{
    public record SizeListDto : IListDto
    {
        public int Id { get; init; }
        public string Value { get; init; }
        public string SizeTypeId { get; init; }
        public List<SupplierProductListDto> SupplierProducts { get; init; }

    }
}
