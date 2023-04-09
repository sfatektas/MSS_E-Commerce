using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.FavoriteProductDtos
{
    public record FavoriteProductListDto : IListDto
    {
        public int Id { get; init; }
        public SupplierProductListDto SupplierProduct { get; set; }
        public int SupplierProdcutsId { get; init; }
        public CustomerListDto Customer { get; set; }
        public int CustomerId { get; init; }
    }
}
