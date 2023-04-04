using E_Commerce.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace E_Commerce.Presentation.Middlewares
{
    public class RequestResponseMiddleware 
    {
        readonly RequestDelegate _next;
        private readonly ILoggerService loggerService;

        public RequestResponseMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            _next = next;
            this.loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            loggerService.Info($"REQUEST -- {context.Request.Path} adresine gelen {context.Request.Method} isteği Kullanıcı Oturum durumu : {context.User.Identity.IsAuthenticated} ");
            await _next.Invoke(context);
            string ip = GetUserIP(context);
            loggerService.Info($"RESPONSE -- {ip} adresine giden {context.Response.StatusCode} kodu ile {context.Response.ContentType} içerik türüne sahip cevap");
        }
        private string GetUserIP(HttpContext context)
        {
            string ip = context.Response.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }
            return ip;
        }
        //Authorize middleware yaz login olduğunda kullanıcı token değerini cache belleğe aktar . 
        //Logout olduğunda cache bellekten sil ve her gelen istek token ile geliyorsa gelen tokenı ilgili kullanıcıya ait
        //cache bellekte bulunan token ile karşılaştır. Eşit değil ise unauthorize dön 
    }
}
