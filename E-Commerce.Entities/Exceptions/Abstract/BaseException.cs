using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions.Abstract
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }

        public BaseException(string message) : base(message)
        {

        }
    }
}
