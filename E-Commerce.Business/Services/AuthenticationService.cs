using AutoMapper;
using E_Commerce.Business.Consts;
using E_Commerce.Business.Helpers;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Common;
using E_Commerce.Dtos;
using E_Commerce.Dtos.CustomerDtos;
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
        readonly IMapper _mapper;
        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, ITokenManager tokenManger, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _tokenManger = tokenManger;
            _mapper = mapper;
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

                    var tokenModel = await _tokenManger.GenerateToken(await GetClaims(user), tokenOptions["SecretKey"], tokenOptions["Audience"], tokenOptions["Issuer"], int.Parse(tokenOptions["ExpireMinitue"]));
                    await _signInManager.SignInAsync(user, false);
                    return tokenModel;
                }
                else
                {
                    throw new UserBadRequestExcepiton($"Parola yanlış tekrar deneyiniz. Kalan deneme hakkı : {IdentityDbOptions.MaxFailedAccessAttempts - await _userManager.GetAccessFailedCountAsync(user)}");
                }
            }
        }
        private async Task<List<Claim>> GetClaims(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id",$"{user.Id}"),
                new Claim(ClaimTypes.NameIdentifier , user.UserName.ToLower()),
                new Claim(ClaimTypes.Email , user.Email.ToLower()),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role , role.ToString().ToLower()));
            }
            return claims;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Register(CustomerCreateDto dto)
        {
            var mappedData = _mapper.Map<Customer>(dto);
            var result = await _userManager.CreateAsync(mappedData , dto.Password);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(mappedData.UserName);
                var roleResult = await _userManager.AddToRoleAsync(user, "customer");
            }
            else
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += "\n" + error.Description;
                }
                throw new UserRegisterBadRequestException(errors);
            }
        }
    }
}
