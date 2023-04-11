using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Interfaces;
using E_Commerce.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories.Abstract
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, IBaseEntity, new()
    {
        readonly E_CommerceDbContext _context;

        public Repository(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindAsync(object id)
        {
            var data = await _context.Set<T>().FindAsync(id);
            return data;
        }

        public  IQueryable<T> GetAllAsync(bool trackChanges = false)
        {
            var list = _context.Set<T>()
                .AsNoTracking();
            return list;
        }
        public IQueryable<T> GetAllAsync( Expression<Func<T, bool>> filter , bool trackChanges = false)
        {
            var list  = (!trackChanges) ? _context.Set<T>()
                .AsNoTracking()
                .Where(filter) :
                _context.Set<T>()
                .AsNoTracking()
                .Where(filter);
            return list;
        }
        public IQueryable<T> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector, OrderByType OrderByType = OrderByType.DESC , bool trackChanges = false)
        {
            var list = (OrderByType == OrderByType.DESC) ?  _context.Set<T>()
                .AsNoTracking()
                .OrderByDescending(keySelector)
                .Where(filter)
                 :
                 _context.Set<T>()
                .AsNoTracking()
                .OrderBy(keySelector)
                .Where(filter);
            return list;
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? 
                await _context.Set<T>().AsNoTracking()
                .SingleOrDefaultAsync(filter) :
                await _context.Set<T>()
                .SingleOrDefaultAsync(filter);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T updated)
        {
            _context.Update(updated);
        }
        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
        public IQueryable<T> GetQueryable(int id)
        {
            return _context.Set<T>().AsQueryable().Where(x => x.Id == id);
        }

    }
}
