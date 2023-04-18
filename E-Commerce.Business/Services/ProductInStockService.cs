using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.CategoryDtos;
using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Entities.EFCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ProductInStockService : Service<ProductsInStockCreateDto, ProductInStockListDto, ProductInStockUpdateDto, ProductsInStock>, IProductInStockService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public ProductInStockService(IUow uow, IMapper mapper, IValidator<ProductsInStockCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<CustomPreviewProductInStockListDto>> GetProductsAsync(string category)
        {
            var data = await _uow.GetRepository<ProductsInStock>()
                .GetQueryable()
                .AsNoTracking()
                .Include(x=>x.SupplierProduct)
                    .Include(x=>x.SupplierProduct.Product)
                    .Include(x=>x.SupplierProduct.Product.Category)
                    .Include(x=>x.SupplierProduct.ProductImages)
                .Where(x=>x.SupplierProduct.Product.Category.Defination.Contains(category))
                .Select(x => new CustomPreviewProductInStockListDto()
                {
                    SupplierProductId = x.SupplierProductId,
                    Brand = _mapper.Map<BrandListDto>(x.SupplierProduct.Product.Brand),
                    Category = _mapper.Map<CategoryListDto>(x.SupplierProduct.Product.Category),
                    ImageUrls = x.SupplierProduct.ProductImages.Select(a=>a.ImageUrl),
                    ProductTitle = x.SupplierProduct.Product.Name,
                    UnitPrice = x.UnitPrice

                })
                .ToListAsync();
            if (data == null)
                throw new Exception("özel kategori türüne göre ürün bulunamadı");
            return data;
        }
    }
}
