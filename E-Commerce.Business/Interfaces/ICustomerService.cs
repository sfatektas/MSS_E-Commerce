using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ICustomerService : IAppUserService<CustomerCreateDto , CustomerListDto , CustomerUpdateDto , Customer>
    {
        Task<List<CustomerListDto>> GetAllCustomerAsync();
    }
}
