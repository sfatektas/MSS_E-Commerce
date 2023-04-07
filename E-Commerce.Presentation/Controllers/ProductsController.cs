using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Business.Services;
using E_Commerce.Common.Enums;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.RequestFeatures;
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
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;
        readonly IMapper _mapper;
        readonly IStorage _storage;

        public ProductsController(IProductService productService, IStorage storage, IMapper mapper)
        {
            _productService = productService;
            _storage = storage;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var data = await _productService.GetAllProductsAsync(true);
            return Ok(data);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttiribute<ProductCreateModel>))] // validator olarak kullanılıyor.
        public async Task<IActionResult> AddProduct([FromForm] ProductCreateModel model)
        {
            var dto = _mapper.Map<ProductCreateDto>(model);
            var imageUrlGuid = Guid.NewGuid().ToString();

            dto.ImageUrl = imageUrlGuid + Path.GetExtension(model.File.FileName);

            var response = await _productService.CreateAsync(dto);
            if (response.ResponseType == ResponseType.Success)
                await _storage.UploadFile(imageUrlGuid, model.File);

            return StatusCode(201);
        }
        //[HttpDelete]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    _productService.RemoveAsync()
        //}
    }
}
