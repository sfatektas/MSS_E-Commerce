using E_Commerce.Dtos;
using E_Commerce.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
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
    public class TestController : ControllerBase
    {
        public TestController() { }

        public IActionResult Get()
        {
            return Ok("It's working");
        }
        [ServiceFilter(typeof(ValidateFilterAttiribute<UserLoginModel>))]
        [HttpPost("[action]")]
        public IActionResult Post([FromBody]UserLoginModel model)
        {
            return Ok();
        }
        [HttpGet("GetError")]
        public IActionResult Error()
        {
            throw new ArgumentNullException();
            return Ok("It's working");
        }
        // var response = _service.GetAllBook();
        [HttpGet("auth")]
        [Authorize]
        public IActionResult IsAuthenticate()
        {
            return Ok("you are already authorize");
        }
    }
}
