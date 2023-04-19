using E_Commerce.Dtos.Interfaces;
using E_Commerce.Dtos.ProductsInStockDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BasketDtos
{
    public class BasketItemListDto 
    {
        public int ProductInStockId { get; init; }
        public ProductInStockListDto ProductInStock { get; set; }
        public int Amount { get; init; }
    }
}
