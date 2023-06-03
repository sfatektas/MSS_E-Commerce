using AutoMapper;
using E_Commerce.Business.Models;
using E_Commerce.Dtos.FavoriteProductDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class FavoriteProductsProfile : Profile
    {
        public FavoriteProductsProfile()
        {
            CreateMap<FavoriteProduct, FavoriteProductListDto>();
            CreateMap<FavoriteProduct,UserFavoriteProductListModel>()
            .ForMember(dest =>dest.UnitPrice , source =>source.MapFrom(x=>x.ProductsInStock.UnitPrice))
            .ForMember(dest =>dest.Brand , source =>source.MapFrom(x=>x.ProductsInStock.SupplierProduct.Product.Brand.Defination))
            .ForMember(dest =>dest.Defination , source =>source.MapFrom(x=>x.ProductsInStock.SupplierProduct.CustomProductDefination))
            .ForMember(dest =>dest.Title , source =>source.MapFrom(x=>x.ProductsInStock.SupplierProduct.CustomProductTitle))
            .ForMember(dest =>dest.ImageUrl , source =>source.MapFrom(x=>x.ProductsInStock.SupplierProduct.ProductImages[0].ImageUrl));
        }
    }
}
