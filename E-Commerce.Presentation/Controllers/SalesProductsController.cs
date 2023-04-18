using E_Commerce.Business.Interfaces;
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
    public class SalesProductsController : ControllerBase
    {
        private readonly IProductInStockService _productInStockService;

        public SalesProductsController(IProductInStockService productInStockService)
        {
            _productInStockService = productInStockService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string category)
        {
            var data = await _productInStockService.GetProductsAsync(category);
            return Ok(data);
        }
    }
}
