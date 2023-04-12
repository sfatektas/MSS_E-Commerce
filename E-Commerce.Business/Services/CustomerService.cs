using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.AppUserDtos;
using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class CustomerService : AppUserService<CustomerCreateDto, CustomerListDto, CustomerUpdateDto, Customer> , ICustomerService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public CustomerService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<CustomerListDto>> GetAllCustomerAsync()
        {
            var data = await _uow.GetIdentityRepository<Customer>().GetQueryable().Include(x => x.Gender).ToListAsync();
            if (data == null)
                throw new CustomerNotFoundException();
            return _mapper.Map<List<CustomerListDto>>(data);
        }
    }
}
