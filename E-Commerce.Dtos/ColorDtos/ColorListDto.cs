using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ColorDtos
{
    public record ColorListDto : IListDto
    {
        public int Id { get; init; }
        public string Defination { get; init; }
        public List<SupplierProductListDto> SupplierProducts { get; init; }
    }
}
