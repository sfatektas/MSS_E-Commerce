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
        

    }
}
