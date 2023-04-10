using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SupplierDtos
{
    public record SupplierUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public string CompanyName { get; init; }
        public string CompanyUserName { get; init; }
        public string CompanyDetail { get; init; }
        public string ImageUrl { get; init; }
    }
}
