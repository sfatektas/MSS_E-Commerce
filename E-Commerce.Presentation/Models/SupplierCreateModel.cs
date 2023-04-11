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
        public string CompanyName { get; init; }
        public string CompanyUserName { get; init; }
        public string CompanyDetail { get; init; }

        private IFormFile _file;

        public IFormFile File
        {
            get { return _file; }
            init {
                if(_file.ContentType.Contains("image"))
                    _file = value; 
            }
        }

    }
}
