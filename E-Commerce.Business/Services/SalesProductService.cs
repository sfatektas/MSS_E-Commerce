using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.BasketDtos;
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

        public async Task<List<CustomPreviewBasketListModel>> GetPreviewBasketProducts(List<int> SalesProductIds)
        {
            var data = await GetIncludeWithAllProperty()
                .Where(x => SalesProductIds.Contains(x.SupplierProductId))
                .Select(x => new CustomPreviewBasketListModel
                {
                    Brand = x.SupplierProduct.Product.Brand.Defination,
                    ImageUrl = x.SupplierProduct.ProductImages.FirstOrDefault().ImageUrl,
                    Title = x.SupplierProduct.CustomProductTitle,
                    UnitPrice = x.UnitPrice
                })
                .ToListAsync();
            return data == null ? throw new Exception("Sepetteki ürünlerin stok durumu şuanda hatalı ") : data;
        }

        private IQueryable<ProductsInStock> GetIncludeWithAllProperty() => _uow.GetRepository<ProductsInStock>()
                .GetQueryable()
                .AsNoTracking()
                .Include(x => x.SupplierProduct.Product)
                    .Include(x => x.SupplierProduct.Product.Brand)
                    .Include(x => x.SupplierProduct.Product.Category)
                .Include(x => x.SupplierProduct.ProductImages);

        public async Task<List<CustomPreviewProductInStockListDto>> GetHomeProducts()
        {
            var data = await _uow.GetRepository<ProductsInStock>()
                .GetQueryable()
                .AsNoTracking()
                .Include(x => x.SupplierProduct.Product)
                    .Include(x => x.SupplierProduct.Product.Brand)
                    .Include(x => x.SupplierProduct.Product.Category)
                .Include(x => x.SupplierProduct.ProductImages)
                .Where(x => x.IsFavoriteProduct && x.IsActive == true)
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

            return data.Count > 0 ?
                data : throw new SalesProductNotFoundException("Seçili Favori ürün bulunmamaktadır");
        }

        public async Task<PagedList<CustomPreviewProductInStockListDto>> GetProductFromParameter(SalesProductRequestParameter parameter)
        {
            var data = await _uow.GetRepository<ProductsInStock>()
                 .GetQueryable()
                 .AsNoTracking()
                 .Include(x => x.SupplierProduct)
                     .Include(x => x.SupplierProduct.Product)
                        .Include(x => x.SupplierProduct.Product.Brand)
                     .Include(x => x.SupplierProduct.Color)
                     .Include(x => x.SupplierProduct.Size)
                 .Where(x =>
                     (string.IsNullOrEmpty(parameter.Color)
                     || x.SupplierProduct.Color.Defination.Contains(parameter.Color, StringComparison.CurrentCultureIgnoreCase))
                     && (string.IsNullOrEmpty(parameter.Search)
                     || x.SupplierProduct.CustomProductTitle.Contains(parameter.Search, StringComparison.CurrentCultureIgnoreCase)
                     || x.SupplierProduct.CustomProductDefination.Contains(parameter.Search, StringComparison.CurrentCultureIgnoreCase)
                     || x.SupplierProduct.Product.Name.Contains(parameter.Search, StringComparison.CurrentCultureIgnoreCase))
                     && (string.IsNullOrEmpty(parameter.Size)
                     || x.SupplierProduct.Size.Value.Contains(parameter.Size))
                     && (string.IsNullOrEmpty(parameter.Brand)
                     || x.SupplierProduct.Product.Brand.Defination.Contains(parameter.Brand))
                     && (string.IsNullOrEmpty(parameter.Category)
                     || x.SupplierProduct.Product.Category.Defination.Contains(parameter.Category, StringComparison.CurrentCultureIgnoreCase))
                     && x.IsActive == true)

                 .Where(x => x.UnitPrice >= parameter.MinPrice &&
                           x.UnitPrice <= parameter.MaxPrice)

                 .Include(x => x.SupplierProduct.Product.Brand) // eğer ki şartları sağlıyorsa dahil ediyoruz.
                 .Include(x => x.SupplierProduct.Product.Category)
                 .Include(x => x.SupplierProduct.Supplier)
                 .Include(x => x.SupplierProduct.ProductImages)
                 .OrderBy(x => x.UnitPrice)
                 .ToListAsync();

            var newdata = data.DistinctBy(x => new {x.SupplierProduct.ProductId , x.SupplierProduct.SupplierId});
            var model = newdata.Select(x => new CustomPreviewProductInStockListDto
            {
                Id = x.Id,
                Brand = _mapper.Map<BrandListDto>(x.SupplierProduct.Product.Brand),
                Category = _mapper.Map<CategoryListDto>(x.SupplierProduct.Product.Category),
                ProductTitle = x.SupplierProduct.CustomProductTitle,
                SupplierProductId = x.SupplierProductId,
                UnitPrice = x.UnitPrice,
                ImageUrls = x.SupplierProduct.ProductImages.Select(x => x.ImageUrl)
            });
            model = string.IsNullOrEmpty(parameter.OrderBy) || parameter.OrderBy.Equals("asc") ? model.OrderBy(x => x.UnitPrice).ToList() : model.OrderByDescending(x => x.UnitPrice).ToList();

            return data.Count > 0 ?
                PagedList<CustomPreviewProductInStockListDto>.ToPagedList(model, parameter.PageSize, parameter.PageNumber)
                : throw new SalesProductNotFoundException();

        }
    }
}
