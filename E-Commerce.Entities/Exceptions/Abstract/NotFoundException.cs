using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions.Abstract
{
    
    public abstract class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }

    }
    public class NotFoundException<T> : BaseException
    {
        public NotFoundException(string message) : base(typeof(T).Name + message)
        {
        }
        public NotFoundException(int id) : base ($"{id} değerine sahip {typeof(T).Name} bulunamadı.")
        {
        }
        public NotFoundException():base($" {typeof(T).Name} türünde kayıtlı veri bulunamadı.")
        {

        }
    }
}
