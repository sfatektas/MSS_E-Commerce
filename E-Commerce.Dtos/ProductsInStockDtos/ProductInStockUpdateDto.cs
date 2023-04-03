using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.ProductsInStockDtos
{
    public record ProductInStockUpdateDto : IUpdateDto
    {
        public int Id { get; init; }
        public int SupplierProductsId { get; init; }
        public double UnitPrice { get; init; }
        public double Amount { get; init; }
    }
}
