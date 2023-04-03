using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions.Abstract
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }

    }
}
