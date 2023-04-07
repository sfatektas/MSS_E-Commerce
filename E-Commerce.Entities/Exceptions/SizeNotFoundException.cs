using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class SizeNotFoundException : NotFoundException
    {
        public SizeNotFoundException(string message) : base(message)
        {
        }
        public SizeNotFoundException(): base("Herhangi bir beden ölçüsü değeri bulunmamaktadır.")
        {

        }
    }
}
