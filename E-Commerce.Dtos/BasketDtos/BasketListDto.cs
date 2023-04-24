using E_Commerce.Dtos.ProductsInStockDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.BasketDtos
{
    public class BasketListDto
    {
        public string CustomerUsername { get; init; }

        public List<BasketItemListDto> BasketItems { get; init; }
        public List<CustomPreviewProductInStockInBasketListDto> BasketItemsWithInclude { get; set; } = new();
    }
}
