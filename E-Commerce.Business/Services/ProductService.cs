using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.EFCore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ProductService : Service<ProductCreateDto, ProductListDto, ProductUpdateDto, Product>, IProductService
    {
        public ProductService(IUow uow, IMapper mapper, IValidator<ProductCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
        }
    }
}
