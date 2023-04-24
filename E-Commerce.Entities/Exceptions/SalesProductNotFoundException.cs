using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class SalesProductNotFoundException : NotFoundException
    {
        public SalesProductNotFoundException(string message) : base(message)
        {
        }
        public SalesProductNotFoundException() : base("İstenen kriterlere ait bir sonuç bulunamadı.")
        {
            
        }
    }
}
