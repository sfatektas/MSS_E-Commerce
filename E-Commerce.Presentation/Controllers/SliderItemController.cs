using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Dtos.SliderItemsDtos;
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
    public class SliderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISliderItemService _sliderItemService;
        private readonly IStorage _storage;

        public SliderItemController(ISliderItemService sliderItemService, IMapper mapper, IStorage storage)
        {
            _sliderItemService = sliderItemService;
            _mapper = mapper;
            _storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliderItems()
        {
            var response = await _sliderItemService.GetAllSliderItemAsync();
            return Ok(response);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttiribute<SliderItemCreateModel>))]
        public async Task<IActionResult> CreateSliderItem([FromForm]SliderItemCreateModel model)
        {
            var dto = _mapper.Map<SliderItemCreateDto>(model);
            var imageUrlGuid = Guid.NewGuid().ToString();
            dto.ImageUrl = imageUrlGuid + Path.GetExtension(model.File.FileName);

            await _sliderItemService.CreateAsync(dto);
            await _storage.UploadFile(imageUrlGuid, model.File);

            return StatusCode(201);
        }
    }
}
