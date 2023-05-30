using E_Commerce.Business.Models;
using E_Commerce.Dtos;
using E_Commerce.Dtos.AppUserDtos;
using E_Commerce.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IAuthenticationService
    {
        Task Register(CustomerCreateDto dto);
        Task<TokenModel> CheckLogin(UserLoginModel model);
        Task Logout();
    }
}
