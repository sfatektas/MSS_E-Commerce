using E_Commerce.Business.Interfaces;
using E_Commerce.Entities.RequestFeatures;
using E_Commerce.Presentation.Helpers;
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
        private readonly ISalesProductService _salesProductService;

        public SalesProductsController(IProductInStockService productInStockService, ISalesProductService salesProductService)
        {
            _productInStockService = productInStockService;
            _salesProductService = salesProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFromFilter([FromQuery] SalesProductRequestParameter parameter)
        {
            var data = await _salesProductService.GetProductFromParameter(parameter);
            HttpContext.Response.AppendMetada(data.MetaData);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketPreviewSalesProducts([FromBody] List<int> ProductInStockIds)
        {
            var data = await _salesProductService.GetPreviewBasketProducts(ProductInStockIds);
            return Ok(data);
        }

        [HttpGet("home")]
        public async Task<IActionResult> GetHomeProducts()
        {
            var data = await _salesProductService.GetHomeProducts();
            return Ok(data);
        }
    }
}
