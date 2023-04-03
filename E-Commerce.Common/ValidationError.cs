using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Common
{
    public class ValidationError
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public ValidationError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

    }
}
