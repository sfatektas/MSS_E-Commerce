using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.SupplierProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsInStockDtos
{
    public record ProductInStockListDto : IListDto
    {
        public int Id { get; init; }
        public int SupplierProductId { get; init; }
        public SupplierProductListDto SupplierProduct { get; set; }             
        public double UnitPrice { get; init; }
        public double Amount { get; init; }
        public bool IsFavoriteProduct { get; init; }

    }
}
