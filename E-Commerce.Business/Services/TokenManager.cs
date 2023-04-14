using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class TokenManager : ITokenManager
    {
        readonly IDistributedCache _cache;
        readonly IHttpContextAccessor _httpContextAccessor;

        public TokenManager(IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TokenModel> GetToken(string username)
        {
            TokenModel model;
            string stringModel =  await _cache.GetStringAsync($"token:{username}");
            if(!string.IsNullOrEmpty(stringModel))
                model = JsonConvert.DeserializeObject<TokenModel>(stringModel);
            return null;
        }
        public async Task<TokenModel> GenerateToken(List<Claim> claims, string key, string audience, string issuer, int expiresMinute)
        {
            var expire = DateTime.UtcNow.AddHours(UtcTimeConstant.TurkeyUTC).AddMinutes(expiresMinute);
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKey = Encoding.UTF8.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = audience,
                Issuer = issuer,
                Expires = expire,
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return new()
            {
                ExpireToken = expire.ToString("MM/dd/yyyy HH:mm:ss"),
                Token = tokenString
            };
        }
        public async Task SetTokenToCache(string username , TokenModel model)
        {
            await _cache.SetStringAsync($"token:{username}", model.ToString());
        }
        public async Task DeleteTokenFromCache(string username)
        {
            try
            {
                await _cache.RemoveAsync($"token:{username}");
            }
            catch (Exception) // cachte olmamama durumu
            {
                return;
            }
        }
        public static string GetUserNameFromToken(string token)
        {
            try
            {
                var parts = token.Split('.');
                var decoded = Convert.FromBase64String(parts[1]);
                var part = Encoding.UTF8.GetString(decoded);
                var jwt = JObject.Parse(part);
                var username = jwt["nameid"].Value<string>();
                return username;
            }
            catch (Exception) // token içerisindeki kullanıcı adı değeri yok ise boş dönsün
            {
                return "";
            }

        }
    }
}
