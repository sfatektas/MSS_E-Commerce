using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore;
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
        public ProductsInStock ProductsInStock { get; set; }
        public int ProductsInStockId { get; init; }
        public CustomerListDto Customer { get; set; }
        public int CustomerId { get; init; }
    }
}
