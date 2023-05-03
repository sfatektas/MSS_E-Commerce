using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.BasketDtos;
using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUow _uow;
        public BasketService(RedisService redisService, UserManager<AppUser> userManager, IConfiguration configuration,  IUow uow)
        {
            _redisService = redisService;
            _userManager = userManager;
            _configuration = configuration;
            _uow = uow;
        }

        public async Task<BasketListDto> GetBasket(string customerusername)
        {
            customerusername = customerusername.ToLower();
            if (await CheckUser(customerusername))
            {
                if (!await _redisService.IsExist($"basket:{customerusername}"))
                {
                    await this.CreateBasket(customerusername);
                    return new()
                    {
                        CustomerUsername = customerusername,
                        BasketItems = null
                    };
                }
                var basket = await _redisService.Get<BasketListDto>($"basket:{customerusername}");
                return await GetBasketJoinProductInStock(basket);
            }
            throw new CustomerNotFoundException($"{customerusername} kullanıcı adına sahip geçerli bir kullanıcı bulunamadı.");
        }

        public async Task CreateOrUpdateBasket(string username, BasketItemCreateDto dto)
        {
            if (await CheckUser(username))
            {
                if (!await _redisService.IsExist($"basket:{username}"))
                    await CreateBasket(username);

                await AddItemToBasket(username, dto);
            }
            else
                throw new CustomerNotFoundException($"{username} kullanıcı adına sahip geçerli bir kullanıcı bulunamadı.");
        }
        private async Task<bool> CheckUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null ? true : false;
        }
        private async Task AddItemToBasket(string username, BasketItemCreateDto dto)
        {
            BasketCreateDto basket = await _redisService.Get<BasketCreateDto>($"basket:{username}");
            basket.BasketItems =
                (basket.BasketItems == null) ? new List<BasketItemCreateDto>() : basket.BasketItems;

            var item = basket.BasketItems
                .FirstOrDefault(x => x.ProductInStockId == dto.ProductInStockId);

            if(item != null )
                basket.BasketItems.Find(x => x.ProductInStockId == item.ProductInStockId).Amount += dto.Amount;
            else
                basket.BasketItems.Add(dto);

            await _redisService.Add($"basket:{username}", basket,
                int.Parse(_configuration["RedisBasketDurationDay"]) * 60 * 24);
        }
        private async Task CreateBasket(string username)
        {
            await _redisService.Add($"basket:{username}",
            new BasketCreateDto()
            {
                CustomerUsername = username,
            },
            int.Parse(_configuration["RedisBasketDurationDay"]));
        }
        private async Task<BasketListDto> GetBasketJoinProductInStock(BasketListDto dto)
        {
            foreach (var item in dto.BasketItems)
            {
                dto.BasketItemsWithInclude.Add(await _uow.GetRepository<ProductsInStock>()
                .GetQueryable()
                .Where(x => x.Id == item.ProductInStockId)
                .Include(x => x.SupplierProduct)
                    .Include(x => x.SupplierProduct.Product)
                .Select(o => new CustomPreviewProductInStockInBasketListDto()
                {
                    Amount = item.Amount,
                    CustomProductTitle = o.SupplierProduct.CustomProductTitle,
                    Id = o.Id,
                    ImageUrl = o.SupplierProduct.Product.ImageUrl,
                    UnitPrice = o.UnitPrice,
                    ProductName = o.SupplierProduct.Product.Name
                })
                .FirstOrDefaultAsync());
            }
            return dto;
        }
    }
}
