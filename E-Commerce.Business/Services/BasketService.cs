using E_Commerce.Business.Interfaces;
using E_Commerce.Dtos.BasketDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using Microsoft.AspNetCore.Identity;
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
        public BasketService(RedisService redisService, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _redisService = redisService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<BasketListDto> GetBasket(string customerusername)
        {
            customerusername = customerusername.ToLower();
            if (await CheckUser(customerusername))
            {
                if (!await _redisService.IsExist($"basket:{customerusername}"))
                {
                    await this.AddBasket(new() { CustomerUsername = customerusername });
                    return new()
                    {
                        CustomerUsername = customerusername,
                        BasketItems = null
                    };
                }
                return await _redisService.Get<BasketListDto>($"basket:{customerusername}");
            }
            throw new CustomerNotFoundException($"{customerusername} kullanıcı adına sahip geçerli bir kullanıcı bulunamadı.");
        }

        public async Task CreateOrUpdateBasket(BasketCreateDto dto)
        {
            if(await CheckUser(dto.CustomerUsername))
                await AddBasket(dto);
        }
        private async Task<bool> CheckUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null ? true : false;
        }
        private async Task AddBasket(BasketCreateDto dto)
        {
            await _redisService.Add($"basket:{dto.CustomerUsername}",
            new BasketListDto()
            {
                CustomerUsername = dto.CustomerUsername,
                BasketItems = dto.BasketItems
            },
            int.Parse(_configuration["RedisBasketDurationDay"]));
        }


    }
}
