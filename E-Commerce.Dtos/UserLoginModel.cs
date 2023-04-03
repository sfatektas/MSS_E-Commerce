using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public record UserLoginModel
    {
        public string UserName { get; init; }

        public string Password { get; init; }
    }
}
