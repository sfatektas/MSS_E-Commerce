using E_Commerce.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Common.Interfaces
{
    public interface IResponse
    {
        public ResponseType ResponseType { get; set; }

        public string Message { get; set; } 
    }
}
