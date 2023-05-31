using AutoMapper;
using Azure;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common;
using E_Commerce.Common.Enums;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        readonly IUow _uow;
        readonly IMapper _mapper;
        public ProductService(IUow uow, IMapper mapper, IValidator<ProductCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> GetAllProductsAsync(bool included = false)
        {
            if (!included)
            {
                var response = await base.GetAllAsync();
                if(response.Data == null)
                    throw new ProductNotFoundException();
                return response.Data;
            }
            else
            {
                var data = await _uow.GetProductRepository()
                    .GetQueryable()
                    .Include(x => x.Brand)
                    .Include(x => x.Category)
                    .Include(x => x.SizeType)
                    .ToListAsync();

                if (data == null)
                    throw new ProductNotFoundException();
                return _mapper.Map<List<ProductListDto>>(data);
            }
        }

        public async Task<List<ProductListDto>> GetAllProductsAsync(Expression<Func<Product, bool>> filter)
        {
            var response = await base.GetAllAsync(filter);
            if (response.Data == null)
                throw new ProductNotFoundException();
            return response.Data;
        }
        public async Task<ProductListDto> GetProductById( int id)
        {
            var response = await base.GetByIdAsync(id);
            if (response.Data == null)
                throw new ProductNotFoundException();
            return response.Data;
        }
    }
}
