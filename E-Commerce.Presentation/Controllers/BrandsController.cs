using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Dtos.BrandDtos;
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
    public class BrandsController : ControllerBase
    {
        readonly IBrandService _Brandservice;
        readonly IMapper _mapper;
        readonly IStorage _storage;

        public BrandsController(IBrandService service, IMapper mapper, IStorage storage)
        {
            _Brandservice = service;
            _mapper = mapper;
            _storage = storage;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var data = await _Brandservice.GetAll();
            return Ok(data);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttiribute<BrandCreateModel>))]
        public async Task<IActionResult> CreateBrand([FromForm] BrandCreateModel model)
        {
            var dto = _mapper.Map<BrandCreateDto>(model);
            var imageUrlGuid = Guid.NewGuid().ToString();

            dto.ImageUrl = imageUrlGuid + Path.GetExtension(model.File.FileName);

            await _Brandservice.AddBrand(dto); // önce ekleme yapsın hata dönmezse sunucuya fotoğrafı kaydetsin.
            await _storage.UploadFile(imageUrlGuid, model.File);

            return StatusCode(201);
        }
        [HttpDelete("{defination}")]
        public async Task<IActionResult> RemoveBrand([FromRoute] string defination)
        {
            await _Brandservice.RemoveBrand(defination);
            return NoContent();
        }

    }
}
