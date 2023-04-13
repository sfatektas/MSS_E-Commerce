using E_Commerce.Entities.RequestFeatures;
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
    public class SupplierProductsController : ControllerBase
    {
        [HttpGet("{supplierid:int}")]
        public async Task<IActionResult> GetSupplierProductsById([FromRoute] int supplierid)
        {
            // return products from supplierid 
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetSupplierFromRequestParameter([FromQuery] SupplierProductRequestParameter parameter)
        {
            return Ok();
        }
    }
}
