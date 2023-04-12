using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Dtos.SupplierDtos;
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
    public class SuppliersController : ControllerBase
    {
        readonly ISupplierService _supplierService;
        readonly IMapper _mapper;
        readonly IStorage _storage;

        public SuppliersController(ISupplierService supplierService, IMapper mapper, IStorage storage)
        {
            _supplierService = supplierService;
            _mapper = mapper;
            _storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var data = await _supplierService.GetAllSupplierAsync();
            return Ok(data);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttiribute<SupplierCreateModel>))]
        public async Task<IActionResult> AddSupplier([FromForm] SupplierCreateModel model)
        {
            var mappedData = _mapper.Map<SupplierCreateDto>(model);
            mappedData.ImageUrl = Guid.NewGuid().ToString();
            await _storage.UploadFile(mappedData.ImageUrl, model.File);
            await _supplierService.CreateSupplierAsync(mappedData);
            return StatusCode(201);
        }
    }
}
