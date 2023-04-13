using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class AppUserNotFoundException : NotFoundException
    {
        public AppUserNotFoundException(string message) : base(message)
        {
        }
        public AppUserNotFoundException() : base("Kullanıcı bulunamadı.")
        {

        }
    }
}
