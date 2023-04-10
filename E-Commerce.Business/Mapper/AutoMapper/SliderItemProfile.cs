using AutoMapper;
using E_Commerce.Dtos.SliderItemsDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class SliderItemProfile : Profile
    {
        public SliderItemProfile()
        {
            CreateMap<SliderItemCreateDto, SliderItem>().ReverseMap();
            CreateMap<SliderItemUpdateDto, SliderItem>().ReverseMap();
            CreateMap<SliderItemListDto, SliderItem>().ReverseMap();
        }
    }
}
