using E_Commerce.Entities.EFCore;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> products,string SortBy )
        {
            if(string.IsNullOrEmpty(SortBy))
                return products.OrderBy(p=>p.Id);
            var query = OrderQueryBuilder.CreateQueryBuilder<Product>(SortBy);
            if(string.IsNullOrEmpty(query))
                return products.OrderBy(p=>p.Id);

            return products.OrderBy(query); // bu yapıyı kullanabilmek için System.Linq.Dynamic.Core kütüphanesini kullanıyorum

        }
    }
}
