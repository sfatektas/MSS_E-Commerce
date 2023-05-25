using E_Commerce.Business.Interfaces;
using E_Commerce.Dtos.BasketDtos;
using E_Commerce.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [EnableCors("DefaultPolicy")]
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
        //[Authorize]
        public async Task<IActionResult> GetBasket([FromRoute] string customername)
        {
            var dto = await _basketService.GetBasket(customername,true);
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
        [Authorize(Roles = "customer")]
        [HttpDelete("{customerName}/{productInStockId:int}")]
        public async Task<IActionResult> DecrementItem([FromRoute] string customerName, int productInStockId)
        {
            await _basketService.DecrementItemFromBasket(customerName, productInStockId);
            return StatusCode(204);
        }
    }
}
