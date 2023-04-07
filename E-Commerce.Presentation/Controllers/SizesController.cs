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
    public class SizesController : ControllerBase
    {
        readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _sizeService.GetAllSize());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllFromSizeTypes(int id)
        {
            return Ok(await _sizeService.GetAllAsync(x=>x.SizeTypeId == id));
        }

    }
    
}
