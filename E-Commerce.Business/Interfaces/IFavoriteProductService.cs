using E_Commerce.Business.Models;
using E_Commerce.Dtos.FavoriteProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IFavoriteProductService
    {
        Task<List<UserFavoriteProductListModel>> GetAllFromUserId(int userId);
        Task SendMailToUsersOfFavoriteProducts(int favoriteProductId);
        Task AddFavoriteProduct(int userId, int productInStockId);
        Task DeleteFavoriteProduct(int userId, int productInStockId);
    }
}
