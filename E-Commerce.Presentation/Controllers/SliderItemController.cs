using AutoMapper;
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
    public class SliderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISliderItemService _sliderItemService;

        public SliderItemController(ISliderItemService sliderItemService, IMapper mapper)
        {
            _sliderItemService = sliderItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliderItems()
        {
            var response = await _sliderItemService.GetAllSliderItemAsync();
            return Ok(response);
        }

    }
}
