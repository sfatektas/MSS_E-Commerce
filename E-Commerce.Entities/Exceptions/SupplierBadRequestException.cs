using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class SupplierBadRequestException : BadRequestException
    {
        public SupplierBadRequestException(string message) : base(message)
        {
        }
        public SupplierBadRequestException():base("Sistemde girilen bilgilere ait bir kayıt mevcut lütfen , email , telefon numarası ve kullanıcı adı alanlarını kontrol ediniz.")
        {

        }
    }
}
