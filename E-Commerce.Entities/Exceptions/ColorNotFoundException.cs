using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class ColorNotFoundException : NotFoundException
    {
        public ColorNotFoundException(string message) : base(message)
        {
            
        }

        public ColorNotFoundException() : base("Renk Verileri Bulunamadı")
        {
            
        }
    }
}
