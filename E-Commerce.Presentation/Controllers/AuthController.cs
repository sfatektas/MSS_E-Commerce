using E_Commerce.Business.Interfaces;
using E_Commerce.Dtos;
using E_Commerce.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [AllowAnonymous] // herhangi bir yetkilendirme işlemi olmayacak
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateFilterAttiribute<UserLoginModel>))]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var tokenModel = await _authenticationService.CheckLogin(model);
            return Ok(tokenModel);
        }
    }
}
