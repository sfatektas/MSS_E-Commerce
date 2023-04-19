using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Middlewares
{
    public class CustomRoutingMiddleware
    {
        readonly RequestDelegate _next;

        public CustomRoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value == "/")
                context.Request.Path = new PathString("/swagger");
            await _next.Invoke(context);
        }
    }
}
