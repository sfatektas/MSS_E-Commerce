using E_Commerce.Business.Interfaces;
using E_Commerce.Presentation.ActionFilters;
using E_Commerce.Presentation.Models;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var listOrder = await _orderService.GetAllOrders();
            return Ok(listOrder);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttiribute<Business.Models.CustomOrderCreateModel>))]
        public async Task<IActionResult> CreateOrderAsync([FromBody]Business.Models.CustomOrderCreateModel model)
        {
            await _orderService.CreateAsyncOrder(model);
            return StatusCode(201);
        }

        //TODO : Sadecce orderStatusType güncellenecek
        //TODO : GetByFilter yapılabilir
        
        [HttpGet("Customers/{id}")]
        public async Task<IActionResult> getCustomerOrders([FromRoute] int id)
        {
            var orders = await _orderService.GetCustomerOrders(id);
            return Ok(orders);
        }

        
        [HttpGet("ProductInStocks/{ProductInStockId}")]
        public async Task<IActionResult> getProductInStocks([FromRoute] int ProductInStockId)
        {
            var orders = await _orderService.GetProductInStocksOrder(ProductInStockId);
            return Ok(orders);
        }

        [HttpPut("Tamamlandi/{orderId}")]
        public async Task<IActionResult> Tamamlandi([FromRoute] int orderId)
        {
            await _orderService.Tamamlandi(orderId);
            return StatusCode(201);
        }

        [HttpPut("IptalEdildi/{orderId}")]
        public async Task<IActionResult> IptalEdildi([FromRoute] int orderId)
        {
            await _orderService.IptalEdildi(orderId);
            return StatusCode(201);
        }

        [HttpPut("KargoyaVerildi/{orderId}")]
        public async Task<IActionResult> KargoyaVerildi([FromRoute] int orderId)
        {
            await _orderService.KargoyaVerildi(orderId);
            return StatusCode(201);
        }

    }
}
