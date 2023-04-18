using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Common.Interfaces;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.ColorDtos;
using E_Commerce.Dtos.ProductImageDtos;
using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Dtos.SizeDtos;
using E_Commerce.Dtos.SupplierDtos;
using E_Commerce.Dtos.SupplierProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using E_Commerce.Entities.RequestFeatures;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class SupplierProductService : Service<SupplierProductCreateDto, SupplierProductListDto, SupplierProductUpdateDto, SupplierProduct>, ISupplierProductService
    {
        readonly IUow _uow;
        readonly IMapper _mapper;
        public SupplierProductService(IUow uow, IMapper mapper, IValidator<SupplierProductCreateDto> createValidator) : base(uow, mapper, createValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }
        private async Task<SupplierProduct> IndexDataIsExistAsync(SupplierProductCreateDto supplierProduct)
        {
            return await _uow.GetRepository<SupplierProduct>()
                .GetByFilterAsync(s => s.ColorId == supplierProduct.ColorId
                                    && s.SupplierId == supplierProduct.SupplierId
                                    && s.ProductId == supplierProduct.ProductId
                                    && s.SizeId == supplierProduct.SizeId);

        }
        public async Task AddProductToStock(int supplierProductId, int amount)
        {
            var data = await _uow.GetRepository<ProductsInStock>().GetByFilterAsync(x => x.SupplierProductId == supplierProductId);
            if (data == null)
                await _uow.GetRepository<ProductsInStock>().CreateAsync(new()
                {
                    SupplierProductId = supplierProductId,
                    Amount = amount,
                });
            else // daha önceden stokta bulunuyorsa eğer , stoktaki ürünün miktarının arttırıyorum.
            {
                data.Amount += amount;
                _uow.GetRepository<ProductsInStock>().Update(data);
                await _uow.SaveChangesAsync();
            }
        }
        public async Task<int> CreateSupplierProduct(SupplierProductCreateDto supplierProduct)
        {
            var existData = await IndexDataIsExistAsync(supplierProduct);
            if (existData == null) // bu bilgilere ait kayıt var mı 
            {
                var response = await base.CreateAsync(supplierProduct);
                if (response.ResponseType != Common.Enums.ResponseType.Success)
                    throw new SupplierProductBadRequestException("Ürün eklenirken bir hata oluştu.");
            }

            var data = await IndexDataIsExistAsync(supplierProduct);

            await this.AddProductToStock(data.Id, supplierProduct.Amount);
            return data.Id;
        }
        public async Task AddImageUrls(List<ProductImageCreateDto> dtos)
        {
            if (dtos != null)
                foreach (var dto in dtos)
                {
                    await _uow.GetRepository<ProductImage>().CreateAsync(_mapper.Map<ProductImage>(dto));
                    await _uow.SaveChangesAsync();
                }
        }
        public async Task<List<ProductInStockListDto>> GetAllWithRequestParameter(SupplierProductRequestParameter parameter)
        {
            var data = await _uow.GetRepository<ProductsInStock>()
                .GetQueryable()
                .Include(x => x.SupplierProduct)
                .Include(x => x.SupplierProduct.Color)
                .Include(x => x.SupplierProduct.Size)
                .Where(x => (x.UnitPrice >= parameter.MinPrice && x.UnitPrice <= parameter.MaxPrice)
                            && string.IsNullOrWhiteSpace(parameter.Color) ? true : x.SupplierProduct.Color.Defination.Contains(parameter.Color)
                            && string.IsNullOrWhiteSpace(parameter.Size) ? true : x.SupplierProduct.Size.Value.Contains(parameter.Size))
                .Skip(parameter.PageSize - 1 * parameter.PageNumber)
                .Take(parameter.PageSize)
                .ToListAsync();
            if (data == null)
                throw new SupplierProductNotFoundException("Aranan kriterlere uygun ürün bulunamadı.");
            return _mapper.Map<List<ProductInStockListDto>>(data);
        }
        public async Task<List<ProductInStockListDto>> GetAllProductInStockAsync(int supplierid)
        {
            // Bu delegate muhabbeti için detaylara bak 
            var data = await _uow.GetRepository<ProductsInStock>()
                .GetQueryable()
                .Include(x => x.SupplierProduct)
                .Where(x => x.SupplierProduct.SupplierId == supplierid)
                .Include(x => x.SupplierProduct.Size)
                .Include(x => x.SupplierProduct.Color)
                .Include(x => x.SupplierProduct.Product)
                .Include(x => x.SupplierProduct.ProductImages)
                .ToListAsync();
            if (data.Count == 0)
                throw new SupplierProductNotFoundException();
            return _mapper.Map<List<ProductInStockListDto>>(data);
        }

        public async Task<CustomProductInStockListDto> GetCustomSupplierProductAsync(int supplierProductId)
        {
            List<DifferentColorAvaibleProductListDto> difcollorList = new();
            List<DifferentSizeAvaibleProductListDto> difsizeList = new();
            // TODO - Uygun olan rekler , uygun olan bedenler ayrı bir model içerisinde ilerlesin.
            var productInStock = await GetSupplierProduct(supplierProductId);
            if (productInStock == null)
                throw new ProductInStockNotFoundException(supplierProductId); // eğer bu ürüne ait bir kayıt yok ise hata döndür.

            List<ProductsInStock> otherSuppliers = await GetOtherSuppliersProduct(
                productInStock.SupplierProduct.ProductId,
                productInStock.SupplierProduct.SupplierId);

            List<(Color color, int ProductInStock)> avaiableColors = await GetAvaiableColors(
                productInStock.SupplierProduct.SupplierId,
                productInStock.SupplierProduct.ProductId,
                productInStock.SupplierProduct.ColorId);

            List<(Size size, int ProductInStock)> avaiableSizes = await GetAvaiableSizes(
                productInStock.SupplierProduct.SupplierId,
                productInStock.SupplierProduct.ProductId,
                productInStock.SupplierProduct.SizeId);

            avaiableColors.ForEach(x =>
                difcollorList.Add(new DifferentColorAvaibleProductListDto
                    {
                        Color = _mapper.Map<ColorListDto>(x.color),
                        SupplierProductId = x.ProductInStock,
                    }));
            avaiableSizes.ForEach(x => 
                difsizeList.Add(new DifferentSizeAvaibleProductListDto
                    {
                        Size = _mapper.Map<SizeListDto>(x.size),
                        SupplierProductId = x.ProductInStock,
                    }));

            return new()
            {
                AvaiableColors = difcollorList,
                AvaiableSizes = difsizeList,
                SupplierProduct = _mapper.Map<ProductInStockListDto>(productInStock),
                SupplierProductsFromOtherSupplier = _mapper.Map<List<ProductInStockListDto>>(otherSuppliers)
            };
        }
        private async Task<ProductsInStock> GetSupplierProduct(int supplierProductId)
        {
            var product = await GetQueryableRepository<ProductsInStock>()
                .Where(x => x.SupplierProductId == supplierProductId)
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Product)
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Color)
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Size)
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Supplier)
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.ProductImages)
                .Include(x => x.SupplierProduct.Product.Brand)
                .Include(x => x.SupplierProduct.Product.Category)
                .FirstOrDefaultAsync();
            return product;
        }
        private async Task<List<ProductsInStock>> GetOtherSuppliersProduct(int productId, int supplierid)
        {
            var othersuppliers = await GetQueryableRepository<ProductsInStock>()
                .Include(x => x.SupplierProduct)
                .Where(x => x.SupplierProduct.ProductId == productId
                            && x.SupplierProduct.SupplierId != supplierid)
                .Include(x => x.SupplierProduct.Supplier)
                .ToListAsync();
            return othersuppliers;
        }
        private async Task<List<(Color color, int ProductInStockId)>> GetAvaiableColors(int supplierid, int productId, int currentColorId)
        {
            var avaiableColors = await GetQueryableRepository<ProductsInStock>()
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Color)
                .Where(x => x.SupplierProduct.SupplierId == supplierid
                        && x.SupplierProduct.ProductId == productId
                        && x.SupplierProduct.ColorId != currentColorId)
                .Select(x => new
                {
                    Color = x.SupplierProduct.Color,
                    SupplierProductId = x.SupplierProductId
                })
                .ToListAsync();
            List<(Color color, int SupplierProductId)> tuple = new();

            avaiableColors.ForEach(item =>
                tuple.Add(new(item.Color, item.SupplierProductId)));
            return tuple;
        }
        private async Task<List<(Size Size, int ProductInStockId)>> GetAvaiableSizes(int supplierId, int productId, int currentSize)
        {
            var avaiableColors = await GetQueryableRepository<ProductsInStock>()
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Size)
                .Where(x => x.SupplierProduct.SupplierId == supplierId
                        && x.SupplierProduct.ProductId == productId
                        && x.SupplierProduct.SizeId != currentSize)
                .Select(x => new
                {
                    Size = x.SupplierProduct.Size,
                    SupplierProductId = x.SupplierProductId
                })
                .ToListAsync();
            List<(Size Size, int SupplierProductId)> tuple = new();

            avaiableColors.ForEach(item =>
                tuple.Add(new(item.Size, item.SupplierProductId)));
            return tuple;
        }
        private IQueryable<T> GetQueryableRepository<T>() where T : BaseEntity, new() => _uow.GetRepository<T>().GetQueryable();

    }
}
