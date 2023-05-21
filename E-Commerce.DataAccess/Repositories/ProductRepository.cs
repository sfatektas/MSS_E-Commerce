using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Repositories.Abstract;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(E_CommerceDbContext context) : base(context)
        {
        }
        public async Task AddProductAsync(Product product) => await CreateAsync(product);
        public void DeleteProductAsycn(Product product) => Remove(product);

        public async Task<PagedList<Product>> GetAllProduct(ProductRequestParameter requestParameter)
        {
            var data = await base.GetAllAsync().ToListAsync();
            return PagedList<Product>.ToPagedList(data, requestParameter.PageSize, requestParameter.PageNumber);
        }
    }
}
