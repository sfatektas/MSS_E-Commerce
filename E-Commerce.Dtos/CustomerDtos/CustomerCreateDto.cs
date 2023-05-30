using E_Commerce.Common.Enums;
using E_Commerce.Dtos.AppUserDtos;
using E_Commerce.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Dtos.CustomerDtos
{
    public record CustomerCreateDto :AppUserCreateDto , ICreateDto
    {
        public CustomerCreateDto()
        {
            base.UserTypeId = (int)AppUserType.Customer;
        }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int GenderId { get; init; }
    }
}
