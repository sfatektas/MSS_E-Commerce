using E_Commerce.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class TokenManager : ITokenManager
    {
        readonly IDistributedCache _cache;
        readonly IHttpContextAccessor _httpContextAccessor;
        public Task DeactivateAsync(string token)
        {
            //_cache.
            throw new NotImplementedException();
        }

        public Task DeactivateCurrentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsActiveAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCurrentActiveToken()
        {
            throw new NotImplementedException();
        }
    }
}
