using AutoMapper;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Entities.EFCore.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<Supplier, SupplierListDto>().ReverseMap();
            CreateMap<SupplierUpdateDto, Supplier>().ReverseMap();
        }
    }
}
