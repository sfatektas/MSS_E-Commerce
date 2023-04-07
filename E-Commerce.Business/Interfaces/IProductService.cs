using E_Commerce.Dtos.ProductDtos;
using E_Commerce.Entities.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IProductService : IService<ProductCreateDto ,ProductListDto , ProductUpdateDto , Product>
    {
        Task<List<ProductListDto>> GetAllProductsAsync(bool include = false);
        Task<List<ProductListDto>> GetAllProductsAsync(Expression<Func<Product, bool>> filter);
        
        //Task Remo

    }
}
