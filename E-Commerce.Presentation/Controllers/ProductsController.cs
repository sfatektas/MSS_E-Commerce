using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Common.Enums;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.RequestFeatures;
using E_Commerce.Presentation.ActionFilters;
using E_Commerce.Presentation.Models;
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
            var data = await _productService.GetAllProductsAsync();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]ProductRequestParameter parameter)
        {
            var data = await _productService.GetAllProductsAsync();
            return Ok(data);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttiribute<ProductCreateModel>))] // validator olarak kullanılıyor.
        public async Task<IActionResult> AddProduct(ProductCreateModel model)
        {
            var dto = _mapper.Map<ProductCreateDto>(model);
            dto.ImageUrl = Guid.NewGuid().ToString();
            
            var response = await _productService.CreateAsync(dto);
            if(response.ResponseType == ResponseType.Success)
                await _storage.UploadFile(dto.ImageUrl, model.File);

            return StatusCode(201);
        }

    }
}
