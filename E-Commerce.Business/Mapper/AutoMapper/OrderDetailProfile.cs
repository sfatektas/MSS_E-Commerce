using AutoMapper;
using E_Commerce.Business.Models;
using E_Commerce.Dtos.OrderDetailDtos;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailListDto>().ReverseMap();
            CreateMap<OrderDetailsCreateDto, OrderDetail>().ReverseMap();
            CreateMap<OrderDetail, CustomOrderCreateModel>().ReverseMap();
            CreateMap<OrderDetailsCreateDto, CustomOrderCreateModel>()./*.ForMember(x=>x.OrderDetailss, x=>x.MapFrom(a=>a)).*/ReverseMap();
        }
    }
}
