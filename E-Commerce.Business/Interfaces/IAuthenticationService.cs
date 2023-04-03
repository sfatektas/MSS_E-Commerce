using E_Commerce.Business.Models;
using E_Commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IAuthenticationService
    {
        Task<TokenModel> CheckLogin(UserLoginModel model);
        Task Logout();
    }
}
