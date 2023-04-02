using E_Commerce.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Middlewares
{
    public class CustomExceptionHandlerMiddleware 
    {
        private readonly ILoggerService _loggerService;
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(ILoggerService loggerService, RequestDelegate next)
        {
            _loggerService = loggerService;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
                await _next.Invoke(context);
			}
			catch (Exception e)
			{
                _loggerService.Error($"Hata mesajı : {e.Message} , Hata Detayı : {e.InnerException}");
                _loggerService.Debug($"Hata mesajı : {e.Message} , Hata Detayı : {e.InnerException}");
            }
        }
    }
}
