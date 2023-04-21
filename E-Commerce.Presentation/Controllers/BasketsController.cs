using E_Commerce.Business.Interfaces;
using E_Commerce.Dtos.BasketDtos;
using E_Commerce.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("{customername}")]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> GetBasket([FromRoute] string customername)
        {
            var dto = await _basketService.GetBasket(customername);
            return Ok(dto);
        }
        [HttpPost("{customername}")]
        public async Task<IActionResult> AddBasket([FromBody] AddBasketCreateModel model)
        {
            await _basketService.CreateOrUpdateBasket(model.Username , 
                new() { 
                    Amount = model.Amount ,
                    ProductInStockId = model.ProductInStockId
                });
            return StatusCode(201);
        }
    }
}
