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
    public class SuppliersController : ControllerBase
    {
        readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var data = await _supplierService.GetAllSupplierAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier()
        {
            return StatusCode(201);
        }
    }
}
