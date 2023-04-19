using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class SupplierProductBadRequestException : BadRequestException
    {
        public SupplierProductBadRequestException(string message) : base(message)
        {
        }
        public SupplierProductBadRequestException() : base("Bir hata oluştu.")
        {
            
        }
    }
}
