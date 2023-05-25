using E_Commerce.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IBasketService
    {
        Task<BasketListDto> GetBasket(string customerusername, bool joinProductInStock = false);
        Task CreateOrUpdateBasket(string username, BasketItemCreateAndUpdateDto dto);
        Task DecrementItemFromBasket(string username, int productInStockId);
    }
}
