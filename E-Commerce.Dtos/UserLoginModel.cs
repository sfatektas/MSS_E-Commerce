using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public record UserLoginModel
    {
        private string _username;


        public string UserName
        {
            get 
            { 
                return _username; 
            }
            set
            {
                _username = value.ToLower();
            }
        }

        public string Password { get; init; }
    }
}
