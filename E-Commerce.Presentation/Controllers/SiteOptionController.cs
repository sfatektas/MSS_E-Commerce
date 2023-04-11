using E_Commerce.Business.Interfaces;
using E_Commerce.Common.Enums;
using E_Commerce.Dtos.SiteOptionDtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    public class SiteOptionController : ControllerBase
    {
        readonly ISiteOptionService _siteOptionService;

        public SiteOptionController(ISiteOptionService siteOptionService)
        {
            _siteOptionService = siteOptionService;
        }
        //sefaEcommerce
       //Tr123456
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             var response = await _siteOptionService.GetOptionAsync();
             if(response.ResponseType == ResponseType.Success)
                return Ok(response.Data);
            return NotFound("Site Ayarları Bulunamadı");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SiteOptionUpdateDto dto)
        {
            await _siteOptionService.UpdateOptionAsync(dto);
            return NoContent();
        }
    }
}
