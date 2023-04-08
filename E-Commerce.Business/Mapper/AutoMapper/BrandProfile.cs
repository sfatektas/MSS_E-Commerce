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
    public class BrandProfile : Profile 
    {
        public BrandProfile()
        {
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<Brand,BrandListDto>().ReverseMap();
        }
    }
}
