using E_Commerce.Dtos.AppUserDtos;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.SupplierDtos
{
    public record SupplierListDto : AppUserListDto,  IListDto
    {
        public string CompanyName { get; init; }
        public string CompanyUserName { get; init; }
        public string CompanyDetail { get; init; }
        public string ImageUrl { get; init; }

        //public List<SupplierProduct> SupplierProducts { get; set; }
    }
}
