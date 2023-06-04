using AutoMapper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Models;
using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Dtos.FavoriteProductDtos;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using E_Commerce.Entities.Exceptions;
using E_Commerce.RabbitMQProducer.Interfaces;
using E_Commerce.RabbitMQProducer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class FavoriteProductsService : ServiceRead<FavoriteProductListDto, FavoriteProduct>, IFavoriteProductService
    {
        private readonly IUow _uow;
        private readonly IMailProducer _mailProducer;
        private readonly IMapper _mapper;

        public FavoriteProductsService(IUow uow, IMapper mapper, IMailProducer mailProducer) : base(uow, mapper)
        {
            _uow = uow;
            _mailProducer = mailProducer;
            _mapper = mapper;
        }

        public async Task<List<UserFavoriteProductListModel>> GetAllFromUserId(int userId)
        {
            var data = await base.GetQueryable()
            .Where(x => x.CustomerId == userId)
            .Include(x => x.ProductsInStock)
                .Include(x => x.ProductsInStock.SupplierProduct)
                    .Include(x => x.ProductsInStock.SupplierProduct.Product)
                        .Include(x => x.ProductsInStock.SupplierProduct.Product.Brand)
                    .Include(x => x.ProductsInStock.SupplierProduct.ProductImages)
            .Include(x => x.Customer)
            .ToListAsync();
            if (data == null)
                throw new FavoriteProductsNotFoundException(userId);
            return _mapper.Map<List<UserFavoriteProductListModel>>(data);
        }
        private async Task<List<string>> GetUserEmailsFromFavoriteProductId(int favoriteProductId)
        {
            var emails = await _uow.GetRepository<FavoriteProduct>()
                .GetQueryable()
                .Where(x => x.ProductsInStockId == favoriteProductId)
                .Include(x => x.Customer)
                .Select(x => x.Customer.Email)
                .ToListAsync();
            return emails;
        }
        public async Task SendMailToUsersOfFavoriteProducts(int favoriteProductId)
        {
            var emails = await this.GetUserEmailsFromFavoriteProductId(favoriteProductId);
            if (emails != null)
            {
                var product = _uow.GetRepository<ProductsInStock>()
                    .GetQueryable()
                    .Include(x => x.SupplierProduct)
                    .FirstOrDefault(x => x.Id == favoriteProductId);

                _mailProducer.SendToMailQueue(new SendMailModel
                {
                    To = emails,
                    Message = $"Favorilerinizde bulunan {product.SupplierProduct.CustomProductTitle} adlı ürünün stok durumu güncellendi. Keyifle alışverişe devam edebilirsiniz."
                });
            }
        }
        public async Task AddFavoriteProduct(int userId, int productInStockId)
        {
            var user = await _uow.GetIdentityRepository<Customer>()
                .GetByFilterAsync(x => x.Id == userId);

            var productInStock = await _uow.GetRepository<ProductsInStock>()
                .GetByFilterAsync(x => x.Id == productInStockId);

            if (user != null && user.UserTypeId != (int)AppUserType.Customer)
                throw new UserNotFoundException(userId);

            if (productInStock != null)
            {
                await _uow.GetRepository<FavoriteProduct>()
                    .CreateAsync(
                    new()
                    {
                        CustomerId = userId,
                        ProductsInStockId = productInStockId
                    });
                await _uow.SaveChangesAsync();
                return;
            }
            throw new ProductInStockNotFoundException(productInStockId);
        }

        public async Task DeleteFavoriteProduct(int userId, int productInStockId)
        {
            var favoriteProduct = await _uow.GetRepository<FavoriteProduct>()
                 .GetByFilterAsync(x => x.CustomerId == userId
                 && x.ProductsInStockId == productInStockId);
            if (favoriteProduct == null)
                throw new FavoriteProductsNotFoundException("Bu kullanıcıya ait silinecek favori ürün bulunmamıştır.");
            _uow.GetRepository<FavoriteProduct>().Remove(favoriteProduct);
            await _uow.SaveChangesAsync();
        }
    }
}
