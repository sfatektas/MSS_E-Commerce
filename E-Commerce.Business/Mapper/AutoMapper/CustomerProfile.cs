using AutoMapper;
using E_Commerce.Dtos.CustomerDtos;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class CustomerProfile : Profile  
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
        }
    }
}
