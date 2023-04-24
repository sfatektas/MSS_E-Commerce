using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Services;
using E_Commerce.Dtos;
using E_Commerce.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [EnableCors("DefaultPolicy")]
    [AllowAnonymous] // herhangi bir yetkilendirme işlemi olmayacak
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        readonly IAuthenticationService _authenticationService;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly ITokenManager _tokenManager;
        readonly RedisService _redisService;
        readonly IConfiguration _configuration;

        public AuthController(IAuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor, ITokenManager tokenManager, RedisService redisService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _httpContextAccessor = httpContextAccessor;
            _tokenManager = tokenManager;
            _redisService = redisService;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidateFilterAttiribute<UserLoginModel>))]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var tokenModel = await _authenticationService.CheckLogin(model);
            await _redisService.Add($"token:{model.UserName}", tokenModel, int.Parse(_configuration.GetSection("JWTTokenOptions")["ExpireMinitue"])); // Büyük harfe çeviriyorum çünki base64stringe çeviriken anlamsız hata verebiliyor.
            await _redisService.Add($"token:{model.UserName}:deactive", tokenModel.Token, 60 * 24);
            // Oturumu devam eden token silindiğinde otomatik olarak eski tokenı kontrol etmek için login işleminde atama yapıyorum.
            return Ok(tokenModel);
        }

        [HttpGet("[action]/{token}")]
        [Authorize]
        public async Task<IActionResult> LogOut([FromRoute]string token) // client tarafından logout actionuna username parametresi gelecek.
        {
            await _authenticationService.Logout();
            if(!string.IsNullOrEmpty(token)) 
            {
                string username = TokenManager.GetUserNameFromToken(token);
                var isComplated = await _redisService.Remove($"token:{username}");
                await _redisService.Add($"token:{username}:deactive", token, 60*24);
                if(isComplated)
                    return StatusCode(204);
                return BadRequest("Token silinemedi veya bulunamadı.");
            }
            return BadRequest(new { error = "Bu kullanıcı adına ait bir oturum mevcut değil." });
        }
    }
}
