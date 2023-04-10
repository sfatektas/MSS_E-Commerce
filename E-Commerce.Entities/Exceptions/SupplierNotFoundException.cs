using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class SupplierNotFoundException : NotFoundException
    {
        public SupplierNotFoundException(string message) : base(message)
        {
        }
        public SupplierNotFoundException() : base("Herhangi bir satıcı bulunmamaktadır.")
        {

        }
    }
}
