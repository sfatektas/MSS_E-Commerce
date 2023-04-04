using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Business.Services;
using E_Commerce.Entities.Exceptions.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Middlewares
{
    public class TokenMiddleware
    {
        readonly RequestDelegate _next;
        readonly IDistributedCache _distributedCache;
        public TokenMiddleware(RequestDelegate requestDelegate, IDistributedCache distributedCache)
        {
            _next = requestDelegate;
            _distributedCache = distributedCache;
        }

        public async Task InvokeAsync(HttpContext context, RedisService redisService)
        {
            var bearerToken = context.Request.Headers.FirstOrDefault(x=>x.Key == "Authorization");
            if (string.IsNullOrEmpty(bearerToken.Value))
                await _next.Invoke(context);
            else 
            {
                var token = bearerToken.Value.ToString().Split(' ')[1];
                var username = TokenManager.GetUserNameFromToken(token);
                var cacheToken = await redisService.Get<TokenModel>($"token:{username}");
                if(cacheToken != null)
                {
                    if (cacheToken.Token != token)
                    {
                        throw new UnAuthorizedException("Lütfen yeniden giriş yapınız."); // bu senaryoya göre aynı anda 2 cihazda oturum açılamaz
                    }
                }
                await _next.Invoke(context);
                var response = context.Response.StatusCode;
            }
        }
    }
}
