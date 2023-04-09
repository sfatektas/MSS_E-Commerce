using E_Commerce.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ITokenManager
    {
        public Task<TokenModel> GenerateToken(List<Claim> claims, string key, string audience, string issuer, int expiresMinute);
        Task DeleteTokenFromCache(string username);
        Task SetTokenToCache(string username, TokenModel model);
    }
}
