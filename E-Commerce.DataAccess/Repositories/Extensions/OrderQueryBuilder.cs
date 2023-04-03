using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories.Extensions
{
    public static class OrderQueryBuilder
    {
        public static String CreateQueryBuilder<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            StringBuilder orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrEmpty(param))
                    continue;
                var propertyFromQueryName = param.Split(' ')[0]; // price desc , title asc gibi query değerininin property değerini aldık
                var objectProperty = propertyInfos.FirstOrDefault(x=>x.Name.Contains(propertyFromQueryName,
                    StringComparison.InvariantCultureIgnoreCase)); // büyük küçük harf duyarsız oldu
                if (objectProperty is null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',',' ');
            return orderQuery;
        }
    }
}
