using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions.Abstract
{
    public abstract class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
