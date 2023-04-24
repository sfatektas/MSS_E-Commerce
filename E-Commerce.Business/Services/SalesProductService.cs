using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.BrandDtos;
using E_Commerce.Dtos.CategoryDtos;
using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.Exceptions;
using E_Commerce.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SalesProductService : ISalesProductService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public SalesProductService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PagedList<CustomPreviewProductInStockListDto>> GetProductFromParameter(SalesProductRequestParameter parameter)
        {
            var data = await _uow.GetRepository<ProductsInStock>()
                 .GetQueryable()
                 .AsNoTracking()
                 .Include(x => x.SupplierProduct)
                     .Include(x => x.SupplierProduct.Product)
                     .Include(x => x.SupplierProduct.Color)
                     .Include(x => x.SupplierProduct.Size)
                        .Include(x => x.SupplierProduct.Size.SizeType)

                 .Where(x =>
                     (string.IsNullOrEmpty(parameter.Color)
                     || x.SupplierProduct.Color.Defination.Contains(parameter.Color, StringComparison.CurrentCultureIgnoreCase))
                     && (string.IsNullOrEmpty(parameter.Search)
                     || x.SupplierProduct.CustomProductTitle.Contains(parameter.Search, StringComparison.CurrentCultureIgnoreCase)
                     || x.SupplierProduct.CustomProductDefination.Contains(parameter.Search, StringComparison.CurrentCultureIgnoreCase)
                     || x.SupplierProduct.Product.Name.Contains(parameter.Search, StringComparison.CurrentCultureIgnoreCase))
                     && (string.IsNullOrEmpty(parameter.Size)
                     || x.SupplierProduct.Size.SizeType.Defination.Contains(parameter.Size))
                     )

                 .Where(x => x.UnitPrice >= parameter.MinPrice &&
                           x.UnitPrice <= parameter.MaxPrice)

                 .Include(x => x.SupplierProduct.Product.Brand) // eğer ki şartları sağlıyorsa dahil ediyoruz.
                 .Include(x => x.SupplierProduct.Product.Category)
                 .Include(x => x.SupplierProduct.Supplier)
                 .Include(x => x.SupplierProduct.ProductImages)
                 .OrderBy(x => x.UnitPrice)
                  .Select(x => new CustomPreviewProductInStockListDto
                  {
                      Brand = _mapper.Map<BrandListDto>(x.SupplierProduct.Product.Brand),
                      Category = _mapper.Map<CategoryListDto>(x.SupplierProduct.Product.Category),
                      ProductTitle = x.SupplierProduct.CustomProductTitle,
                      SupplierProductId = x.SupplierProductId,
                      UnitPrice = x.UnitPrice,
                      ImageUrls = x.SupplierProduct.ProductImages.Select(x => x.ImageUrl)
                  })
                 .ToListAsync();
            data = string.IsNullOrEmpty(parameter.OrderBy) || parameter.OrderBy.Equals("asc") ? data.OrderBy(x => x.UnitPrice).ToList() :data.OrderByDescending(x => x.UnitPrice).ToList();

            return data.Count > 0 ?
                PagedList<CustomPreviewProductInStockListDto>.ToPagedList(data, parameter.PageSize, parameter.PageNumber)
                : throw new SalesProductNotFoundException();

        }
    }
}
