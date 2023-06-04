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
            CreateMap<OrderDetailsCreateDto, CustomOrderCreateModel>()./*.ForMember(x=>x.OrderDetail, x=>x.MapFrom(a=>a)).*/ReverseMap();

            CreateMap<CustomOrderDetailsListModel,OrderDetail>()
                .ForPath(x => x.SupplierProduct.CustomProductTitle, x => x.MapFrom(x => x.Title))
                .ForPath(x => x.SupplierProduct.CustomProductDefination, x => x.MapFrom(x => x.Definition))
                .ForMember(x => x.UnitPrice, x => x.MapFrom(x => x.UnitPrice))
                .ForMember(x => x.Amount, x => x.MapFrom(x => x.Amount))
                .ForMember(x => x.TotalPrice, x => x.MapFrom(x => x.TotalPrice))
                .ForPath(x => x.Order.CustomerId, x => x.MapFrom(x => x.CustomerId))
                .ForPath(x => x.Order.Customer.FirstName, x => x.MapFrom(x => x.CustomerName))
                .ForMember(x => x.SupplierProductId, x => x.MapFrom(x => x.SupplierProductInStockId))
                .ForPath(x=>x.SupplierProduct.Supplier.CompanyName, x=>x.MapFrom(x=>x.SupplierProductName))
                .ForPath(x=>x.Order.Customer.Email, x=>x.MapFrom(x=>x.CustomerEmail))
                .ForPath(x=>x.Order.CreatedDate, x=>x.MapFrom(x=>x.OrderDate))
                .ReverseMap();

            /*CreateMap<CustomerOrderListModel, OrderDetail>()
                .ForPath(x => x.SupplierProduct.Supplier, x => x.MapFrom(x => x.SupplierProductName))

                .ForMember(x => x.UnitPrice, x => x.MapFrom(x => x.UnitPrice))
                .ForMember(x => x.Amount, x => x.MapFrom(x => x.Amount))
                .ForMember(x => x.TotalPrice, x => x.MapFrom(x => x.TotalPrice))
                .ForPath(x => x.Order.CreatedDate, x => x.MapFrom(x => x.OrderDate))
                .ForPath(x => x.Order.OrderStatusType.Defination, x => x.MapFrom(x => x.OrderStatusValue))
                .ReverseMap();
            */
        }
    }
}
