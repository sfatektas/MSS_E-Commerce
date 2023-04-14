using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Helpers
{
    public static class ExtensionMethods
    {
        public static async Task ReturnResponse(this HttpContext context, string body, int statuscode, string contentType)
        {
            context.Response.StatusCode = statuscode;
            context.Response.ContentType = contentType;
            await context.Response.WriteAsync(body);
            return;
        }
    }
}
