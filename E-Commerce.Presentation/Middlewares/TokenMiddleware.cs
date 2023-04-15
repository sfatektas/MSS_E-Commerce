using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Business.Services;
using E_Commerce.Entities.Exceptions;
using E_Commerce.Entities.Exceptions.Abstract;
using E_Commerce.Presentation.Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Middlewares
{
    [EnableCors("DefaultPolicy")]
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
            var bearerToken = context.Request.Headers.FirstOrDefault(x => x.Key == "Authorization");
            if (string.IsNullOrEmpty(bearerToken.Value))
                await _next.Invoke(context);
            else
            {
                var token = bearerToken.Value.ToString().Split(' ')[1];
                var username = TokenManager.GetUserNameFromToken(token);
                if (await redisService.IsExist($"token:{username}"))
                {
                    var cacheToken = await redisService.Get<TokenModel>($"token:{username}");
                    if (cacheToken.Token != token)
                    {
                        await context.ReturnResponse(new ErrorModel()
                        {
                            Error = "Oturumunuzun süresi dolmuştur lütfen yeniden oturum açınız.",
                            StatusCode = (int)HttpStatusCode.Unauthorized
                        }.ToString(), (int)HttpStatusCode.Unauthorized, "application/json");
                        return;
                         // bu senaryoya göre aynı anda 2 cihazda oturum açılamaz
                    }
                    await _next.Invoke(context);
                }
                else if (await redisService.IsExist($"token:{username}:deactive"))
                {
                    string expireToken = await redisService.Get<string>($"token:{username}:deactive");
                    if (token == expireToken)
                    {
                        await context.ReturnResponse(new ErrorModel()
                        {
                            Error = "Oturumunuzun süresi dolmuştur lütfen yeniden oturum açınız.",
                            StatusCode = (int)HttpStatusCode.Unauthorized
                        }.ToString(), (int)HttpStatusCode.Unauthorized, "application/json");
                        return;
                    }
                    await _next.Invoke(context);

                }
                else
                {
                    await context.ReturnResponse(new ErrorModel()
                    {
                        Error = "Geçersiz Token",
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    }.ToString(), (int)HttpStatusCode.Unauthorized, "application/json");
                    return;
                }
            }
        }
    }
}
