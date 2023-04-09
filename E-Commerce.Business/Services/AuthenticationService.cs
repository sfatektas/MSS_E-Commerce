using E_Commerce.Business.Consts;
using E_Commerce.Business.Helpers;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Common;
using E_Commerce.Dtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IConfiguration _configuration;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenManager _tokenManger;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, ITokenManager tokenManger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _tokenManger = tokenManger;
        }
        public async Task<TokenModel> CheckLogin(UserLoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                throw new UserNotFoundException(model.UserName);
            else
            {
                var result= await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);
                if(result.IsLockedOut)
                {
                    var endDate = await _userManager.GetLockoutEndDateAsync(user);
                    throw new UserBadRequestExcepiton($"Hesabınız {endDate.Value.UtcDateTime.AddHours(UtcTimeConstant.TurkeyUTC).ToString()} tarihe kadar kitlenmiştir.");
                }
                else if (result.Succeeded)
                {
                    var tokenOptions = _configuration.GetSection("JWTTokenOptions");

                    var tokenModel = await _tokenManger.GenerateToken(GetClaims(user), tokenOptions["SecretKey"], tokenOptions["Audience"], tokenOptions["Issuer"], int.Parse(tokenOptions["ExpireMinitue"]));
                    await _signInManager.SignInAsync(user, false);
                    return tokenModel;
                }
                else
                {
                    throw new UserBadRequestExcepiton($"Parola yanlış tekrar deneyiniz. Kalan deneme hakkı : {IdentityDbOptions.MaxFailedAccessAttempts - await _userManager.GetAccessFailedCountAsync(user)}");
                }
            }
        }
        private List<Claim> GetClaims(AppUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id",$"{user.Id}"),
                new Claim(ClaimTypes.NameIdentifier , user.UserName),
                new Claim(ClaimTypes.Email , user.Email),
            };
            return claims;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
