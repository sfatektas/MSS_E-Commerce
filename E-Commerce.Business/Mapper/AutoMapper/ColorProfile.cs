using AutoMapper;
using E_Commerce.Dtos.ColorDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color,ColorListDto>();
        }
    }
}
