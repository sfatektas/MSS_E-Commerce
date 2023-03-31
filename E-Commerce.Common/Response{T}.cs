using E_Commerce.Common.Enums;
using E_Commerce.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Common
{
    public class Response<T> : Response ,  IResponse<T> where T : class
    {
        public T Data { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message, T data) : base(responseType, message)
        {
            this.Data = data;
        }

        public Response(ResponseType responseType, string message, T data, List<ValidationError> validationErrors) : this(responseType, message, data)
        {
            this.ValidationErrors = validationErrors;
        }
    }
}
