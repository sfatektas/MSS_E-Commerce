using E_Commerce.Entities.RequestFeatures;
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
        public static void AppendMetada(this HttpResponse response,MetaData metaData)
        {
            response.Headers.Add("itemCount",metaData.ItemCount.ToString());
            response.Headers.Add("totalPage",metaData.TotalPage.ToString());
            response.Headers.Add("pageSize",metaData.PageSize.ToString());
            response.Headers.Add("hasPrev",metaData.HasPrev.ToString());
            response.Headers.Add("hasNext",metaData.HasNext.ToString());
            response.Headers.Add("currentPage",metaData.CurrentPage.ToString());

        }
    }
}
