using E_Commerce.Business.Interfaces;
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
    public class SizeTypesController : ControllerBase
    {
        private readonly ISizeTypeService _sizeTypeService;

        public SizeTypesController(ISizeTypeService sizeTypeService)
        {
            _sizeTypeService = sizeTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sizeTypeService.GetAllAsync();
            return Ok(result.Data);
        }
    }
}
