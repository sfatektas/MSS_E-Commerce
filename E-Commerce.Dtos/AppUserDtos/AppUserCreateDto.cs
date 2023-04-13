using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.AppUserDtos
{
    //Supplier Controller will add
    public abstract record AppUserCreateDto : ICreateDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public string PasswordConfirm { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public int UserTypeId { get; set; }

    }
}
