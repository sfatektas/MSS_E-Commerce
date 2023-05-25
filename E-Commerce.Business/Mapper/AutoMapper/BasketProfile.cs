using AutoMapper;
using E_Commerce.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketListDto, BasketCreateDto>();
            CreateMap<BasketItemListDto, BasketItemCreateAndUpdateDto>();
        }
    }
}
