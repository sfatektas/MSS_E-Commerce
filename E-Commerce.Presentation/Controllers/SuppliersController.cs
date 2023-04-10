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
    public class SuppliersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier()
        {
            return StatusCode(201);
        }
    }
}
