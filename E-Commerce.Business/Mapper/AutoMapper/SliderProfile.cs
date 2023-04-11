using AutoMapper;
using E_Commerce.Dtos.SliderDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderCreateDto, Slider>().ReverseMap();
            CreateMap<SliderUpdateDto, Slider>().ReverseMap();
            CreateMap<SliderListDto, Slider>().ReverseMap();
        }
    }
}
