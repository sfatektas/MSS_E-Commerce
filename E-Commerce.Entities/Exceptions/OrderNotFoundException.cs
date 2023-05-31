using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{

    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(string message) : base(message)
        {
        }

        public OrderNotFoundException() :base("Order verileri bulunamadı")
        {
            
        }
    }
}
