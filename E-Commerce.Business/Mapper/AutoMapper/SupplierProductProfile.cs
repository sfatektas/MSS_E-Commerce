using AutoMapper;
using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class SupplierProductProfile : Profile
    {
        public SupplierProductProfile()
        {
            CreateMap<SupplierProductCreateDto, SupplierProduct>();
            CreateMap<SupplierProduct,SupplierProductListDto>().ReverseMap();
        }
    }
}
