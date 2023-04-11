using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class SliderItemNotFoundException : NotFoundException
    {
        public SliderItemNotFoundException(string message) : base(message)
        {
            
        }
        public SliderItemNotFoundException() : base("Herhangi bir Slider Item bulunamadı")
        {
            
        }
    }
}
