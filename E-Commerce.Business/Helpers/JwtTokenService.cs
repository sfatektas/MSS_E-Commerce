using E_Commerce.Business.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Helpers
{
    public class JwtTokenService
    {
        public static TokenModel GenerateToken(List<Claim> claims , string key , string audience , string issuer , int expiresMinute)
        {
            var expire = DateTime.UtcNow.AddMinutes(expiresMinute);
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
            return new() { 
                ExpireToken = expire ,
                Token = tokenString
            };
        }
    }
}
