﻿using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common.Interfaces;
using E_Commerce.Dtos.SliderDtos;
using E_Commerce.Presentation.ActionFilters;
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
    public class SliderController : ControllerBase
    {

        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSlider()
        {
            var response = await _sliderService.GetAllSliderAsync();
            return Ok(response);
        }
    }
}
