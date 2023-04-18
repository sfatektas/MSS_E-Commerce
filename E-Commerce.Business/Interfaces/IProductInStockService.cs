using E_Commerce.Dtos.ProductsInStockDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IProductInStockService : IService<ProductsInStockCreateDto,ProductInStockListDto,ProductInStockUpdateDto,ProductsInStock>
    {
        Task<List<CustomPreviewProductInStockListDto>> GetProductsAsync(string category);

    }
}
