using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Models
{
    public record TokenModel
    {
        public string Token { get; set; }

        public DateTime ExpireToken { get; set; }
    }
}
