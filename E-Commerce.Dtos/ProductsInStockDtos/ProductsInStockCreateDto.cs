using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsInStockDtos
{
    public record ProductsInStockCreateDto : ICreateDto
    {
        public int SupplierProductsId { get; init; }
        public double UnitPrice { get; init; }
        public double Amount { get; init; }
    }
}
