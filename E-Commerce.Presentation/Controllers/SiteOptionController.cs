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
            var data = await _siteOptionService.GetOptionAsync();
            return Ok(data);
        }
    }
}
