using AutoMapper;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.CategoryDtos;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Dtos.SizeDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductListDto>();
        }
    }
}
