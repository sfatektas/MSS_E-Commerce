using E_Commerce.Business.Interfaces;
using E_Commerce.Entities.Exceptions;
using E_Commerce.Entities.Exceptions.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
            catch (BaseException e)
            {
                _loggerService.Error($"Hata mesajı : {e.Message} , Hata Detayı : {e.InnerException}");
                //Will Create custom response model
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsync(new ErrorModel()
                {
                    StatusCode = e.StatusCode,
                    Error = e.Message,
                }.ToString());
            }
            catch (Exception e)
            {
                _loggerService.Error($"Hata mesajı : {e.Message} ,\n Hata Detayı : {e.InnerException}");
                //Will Create custom response model
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(new ErrorModel()
                {
                    Error = $"Hata mesajı : {e.Message} ,\n Hata Detayı : {e.InnerException}",
                }.ToString());
            }
        }
    }
}
