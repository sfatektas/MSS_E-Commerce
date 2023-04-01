using E_Commerce.Common.Enums;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Interfaces;
using E_Commerce.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity , IBaseEntity, new()
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);

        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector, OrderByType OrderByType = OrderByType.DESC);
        Task CreateAsync(T entity);

        Task<T> FindAsync(object id);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        void Remove(T entity);

        void Update(T unchanged, T updated);

        IQueryable<T> GetQueryable();

        IQueryable<T> GetQueryable(int id);
    }
}
