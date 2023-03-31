using E_Commerce.Common.Enums;
using E_Commerce.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Common
{
    public class Response : IResponse
    {
        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message) : this(responseType)
        {
            Message = message;
        }

    }
}
