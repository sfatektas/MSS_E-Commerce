using AutoMapper;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class BrandProfile<T> : Profile 
    {
        public BrandProfile()
        {
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<T, BrandCreateDto>();
            CreateMap<Brand,BrandListDto>().ReverseMap();
        }
    }
}
