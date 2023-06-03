using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Interfaces.Storage;
using E_Commerce.Business.Models;
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
using E_Commerce.RabbitMQProducer.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        readonly IStorage _storage;
        readonly IFavoriteProductService _favoreiteProductService;

        public SupplierProductService(IUow uow, IMapper mapper, IValidator<SupplierProductCreateDto> createValidator, IStorage storage, IFavoriteProductService favoreiteProductService) : base(uow, mapper, createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _storage = storage;
            _favoreiteProductService = favoreiteProductService;
        }
        public async Task RemoveSupplierProductImage(int supplierProductId, string imageUrl)
        {
            var datas = await _uow.GetRepository<ProductImage>().GetAllAsync(x => x.SupplierProductId == supplierProductId).ToListAsync();
            if (datas.Count() == 1)
                throw new Exception("Ürün en az bir resime sahip olmalıdır.");

            var row =  datas.FirstOrDefault(x => x.SupplierProductId == supplierProductId && x.ImageUrl == imageUrl);
            if (row == null)
                throw new Exception($"{supplierProductId} id ile eşleşen bu {imageUrl} e sahip bir kayıt bulunmamaktadır");

            if (_storage.RemoveFile(imageUrl)) // removed from db when image removed from server
            {
                _uow.GetRepository<ProductImage>().Remove(row);
                await _uow.SaveChangesAsync();
            }
        }
        public async Task UpdateSupplierProduct(SupplierProductUpdateModel model)
        {
            bool sendMail = false;
            var product = await _uow.GetRepository<SupplierProduct>().GetByFilterAsync(x => x.Id == model.Id,true);

            product.SizeId = model.SizeId;
            product.UnitPrice = model.UnitPrice;
            product.ColorId = model.ColorId;
            product.CustomProductDefination = model.CustomProductDefination;
            product.CustomProductTitle = model.CustomProductTitle;
            product.IsActive = model.IsActive;
            product.UnitPrice = model.UnitPrice;
            
            // PRoductInStock Updated.
            var stockProduct = await _uow.GetRepository<ProductsInStock>().GetByFilterAsync(x=>x.SupplierProductId == model.Id);
            if (stockProduct.Amount != model.Amount)
            {
                stockProduct.Amount = model.Amount;
                sendMail = true;
            }
            stockProduct.UnitPrice = model.UnitPrice;
             _uow.GetRepository<ProductsInStock>().Update(stockProduct);
            await _uow.SaveChangesAsync();
            // Send Mail 
            if (sendMail)
                await _favoreiteProductService.SendMailToUsersOfFavoriteProducts(stockProduct.Id);
            //TODO : Product In Stock Güncellenecek

            if (model.Files.Count() > 0)
            {
                var list = model.Files.Select(x => new 
                {
                    SupplierProductId = product.Id,
                    ImageUrl = Guid.NewGuid().ToString(),
                    File = x
                }).ToList();

                foreach (var item in list)
                {
                    await _storage.UploadFile(item.ImageUrl, item.File);
                    await _uow.GetRepository<ProductImage>().CreateAsync(new()
                    {
                        SupplierProductId = item.SupplierProductId,
                        ImageUrl = item.ImageUrl + Path.GetExtension(item.File.FileName),
                    });
                    await _uow.SaveChangesAsync();
                }
            }
            await base.UpdateAsync(_mapper.Map<SupplierProductUpdateDto>(product)); // herhangi bir fotoğraf güncellemesi olmasa bile diğer datalar güncelleniyor.
        }

        public async Task DeleteSupplierProduct(int id)
        {
            var supplierProduct = await base.GetByFilterAsync(x => x.Id == id);
            if (supplierProduct.ResponseType == Common.Enums.ResponseType.NotFound)
                throw new SupplierProductNotFoundException($"{id} değerine sahip silinecek bir ürün mevcut değil");

            var updatedto = _mapper.Map<SupplierProductUpdateDto>(supplierProduct.Data);
            updatedto.IsActive = false;
            await base.UpdateAsync(updatedto);

            var data = await this.GetSupplierProduct(supplierProduct.Data.Id);
            data.IsActive = false;

            _uow.GetRepository<ProductsInStock>().Update(data);
            await _uow.SaveChangesAsync();
        }
        private async Task<SupplierProduct> IndexDataIsExistAsync(SupplierProductCreateDto supplierProduct)
        {
            return await _uow.GetRepository<SupplierProduct>()
                .GetByFilterAsync(s => s.ColorId == supplierProduct.ColorId
                                    && s.SupplierId == supplierProduct.SupplierId
                                    && s.ProductId == supplierProduct.ProductId
                                    && s.SizeId == supplierProduct.SizeId);

        }
        public async Task<bool> AddProductToStock(int supplierProductId, int amount, double unitprice)
        {
            bool isexist = false; // returns true if exist product otherwise false 
            var data = await _uow.GetRepository<ProductsInStock>().GetByFilterAsync(x => x.SupplierProductId == supplierProductId);
            if (data == null)
                await _uow.GetRepository<ProductsInStock>().CreateAsync(new()
                {
                    SupplierProductId = supplierProductId,
                    Amount = amount,
                    UnitPrice = unitprice
                });
            else // daha önceden stokta bulunuyorsa eğer , stoktaki ürünün miktarının arttırıyorum.
            {
                data.Amount += amount;
                data.UnitPrice = unitprice;
                _uow.GetRepository<ProductsInStock>().Update(data);
                await _uow.SaveChangesAsync();
            }
            return isexist;
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

            await this.AddProductToStock(data.Id, supplierProduct.Amount, supplierProduct.UnitPrice);
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
                .Where(x => x.SupplierProduct.SupplierId == supplierid && x.IsActive == true)
                .Include(x => x.SupplierProduct.Size)
                .Include(x => x.SupplierProduct.Color)
                .Include(x => x.SupplierProduct.Product)
                    .Include(x => x.SupplierProduct.Product.SizeType)
                    .Include(x => x.SupplierProduct.Product.Brand)
                    .Include(x => x.SupplierProduct.Product.Category)
                .Include(x => x.SupplierProduct.ProductImages)
                .ToListAsync();
            if (data.Count == 0)
                throw new SupplierProductNotFoundException();
            return _mapper.Map<List<ProductInStockListDto>>(data);
        }

        public async Task<CustomProductInStockListDto> GetCustomSupplierProductAsync(int productinstockid)
        {
            List<DifferentColorAvaibleProductListDto> difcollorList = new();
            List<DifferentSizeAvaibleProductListDto> difsizeList = new();
            // TODO - Uygun olan rekler , uygun olan bedenler ayrı bir model içerisinde ilerlesin.
            var productInStock = await GetSupplierProduct(productinstockid);
            if (productInStock == null)
                throw new ProductInStockNotFoundException(productinstockid); // eğer bu ürüne ait bir kayıt yok ise hata döndür.

            List<ProductsInStock> otherSuppliers = await GetOtherSuppliersProduct(
                productInStock.SupplierProduct.ProductId,
                productInStock.SupplierProduct.SupplierId);

            List<(Color color, int Id)> avaiableColors = await GetAvaiableColors(
                productInStock.SupplierProduct.SupplierId,
                productInStock.SupplierProduct.ProductId,
                productInStock.SupplierProduct.ColorId,
                productInStock.SupplierProduct.SizeId);

            List<(Size size, int Id)> avaiableSizes = await GetAvaiableSizes(
                productInStock.SupplierProduct.SupplierId,
                productInStock.SupplierProduct.ProductId,
                productInStock.SupplierProduct.SizeId,
                productInStock.SupplierProduct.ColorId);

            avaiableColors.ForEach(x =>
                difcollorList.Add(new DifferentColorAvaibleProductListDto
                {
                    Color = _mapper.Map<ColorListDto>(x.color),
                    Id = x.Id,
                }));
            avaiableSizes.ForEach(x =>
                difsizeList.Add(new DifferentSizeAvaibleProductListDto
                {
                    Size = _mapper.Map<SizeListDto>(x.size),
                    Id = x.Id,
                }));

            return new()
            {
                AvaiableColors = difcollorList,
                AvaiableSizes = difsizeList,
                ProductInStock = _mapper.Map<ProductInStockListDto>(productInStock),
                SupplierProductsFromOtherSupplier = _mapper.Map<List<ProductInStockListDto>>(otherSuppliers)
            };
        }
        private async Task<ProductsInStock> GetSupplierProduct(int productinstockid)
        {
            var product = await GetQueryableRepository<ProductsInStock>()
                .Where(x => x.Id == productinstockid)
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
                .GroupBy(x => x.SupplierProduct.SupplierId)
                .Select(x => x.FirstOrDefault())
                .ToListAsync();
            return othersuppliers;
        }
        private async Task<List<(Color color, int Id)>> GetAvaiableColors(int supplierid, int productId, int currentColorId, int sizeId)
        {
            var avaiableColors = await GetQueryableRepository<ProductsInStock>()
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Color)
                .Where(x => x.SupplierProduct.SupplierId == supplierid
                        && x.SupplierProduct.ProductId == productId
                        && x.SupplierProduct.SizeId == sizeId
                        && x.SupplierProduct.ColorId != currentColorId)
                .Select(x => new
                {
                    Color = x.SupplierProduct.Color,
                    Id = x.Id
                })
                .ToListAsync();
            List<(Color color, int Id)> tuple = new();

            avaiableColors.ForEach(item =>
                tuple.Add(new(item.Color, item.Id)));
            return tuple;
        }
        private async Task<List<(Size Size, int Id)>> GetAvaiableSizes(int supplierId, int productId, int currentSize, int colorId)
        {
            var avaiableColors = await GetQueryableRepository<ProductsInStock>()
                .Include(x => x.SupplierProduct)
                    .ThenInclude(x => x.Size)
                .Where(x => x.SupplierProduct.SupplierId == supplierId
                        && x.SupplierProduct.ProductId == productId
                        && x.SupplierProduct.ColorId == colorId
                        && x.SupplierProduct.SizeId != currentSize)
                .Select(x => new
                {
                    Size = x.SupplierProduct.Size,
                    Id = x.Id
                })
                .ToListAsync();
            List<(Size Size, int Id)> tuple = new();

            avaiableColors.ForEach(item =>
                tuple.Add(new(item.Size, item.Id)));
            return tuple;
        }
        private IQueryable<T> GetQueryableRepository<T>() where T : BaseEntity, new() => _uow.GetRepository<T>().GetQueryable();

    }
}
