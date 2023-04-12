using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Models
{
    // TODO AppUserSeedData will add
    public class SupplierCreateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUserName { get; set; }
        public string CompanyDetail { get; set; }

        private IFormFile _file;

        public IFormFile File
        {
            get { return _file; }
            init {
                if (value.ContentType.Contains("image"))
                    _file = value; 
            }
        }

    }
}
