using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ProductService : Service<ProductCreateDto, ProductListDto, ProductUpdateDto, Product>, IProductService
    {
        public ProductService(IUow uow, IMapper mapper, IValidator<ProductCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
        }

        public async Task<List<ProductListDto>> GetAllProductsAsync()
        {
            var response = await base.GetAllAsync();
            if (response.Data == null)
                throw new ProductNotFoundException();
            return response.Data;
        }

        public async Task<List<ProductListDto>> GetAllProductsAsync(Expression<Func<Product, bool>> filter)
        {
            var response = await base.GetAllAsync(filter);
            if (response.Data == null)
                throw new ProductNotFoundException();
            return response.Data;
        }
    }
}
