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
        [HttpGet("{customerid}")]
        public async Task<IActionResult> GetBasket([FromRoute] string customerid)
        {
            return Ok();
        }
    }
}
