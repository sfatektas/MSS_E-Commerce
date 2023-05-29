using AutoMapper;
using E_Commerce.Dtos.ProductCommentDtos;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Mapper.AutoMapper
{
    public class ProductCommentProfile : Profile
    {
        public ProductCommentProfile()
        {
            CreateMap<ProductCommentCreateDto, ProductComment>().ReverseMap();
            CreateMap<ProductComment, ProductCommentListDto>();
        }
    }
}
