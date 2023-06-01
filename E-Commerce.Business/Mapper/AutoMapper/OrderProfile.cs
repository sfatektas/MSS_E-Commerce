using AutoMapper;
using E_Commerce.Business.Models;
using E_Commerce.Dtos.OrderDtos;
using E_Commerce.Entities.EFCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order = E_Commerce.Entities.EFCore.Order;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderListDto>().ReverseMap();
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
            CreateMap<Order, CustomOrderCreateModel>().ReverseMap();
        }
    }
}
