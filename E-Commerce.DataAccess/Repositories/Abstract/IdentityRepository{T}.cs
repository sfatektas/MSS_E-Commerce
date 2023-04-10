using E_Commerce.Common.Enums;
using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.Entities.EFCore.Identities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Repositories.Abstract
{
    public class IdentityRepository<T> : IIdentityRepository<T> where T : AppUser, new()
    {
        readonly E_CommerceDbContext _context;

        public IdentityRepository(E_CommerceDbContext context)
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

        public async Task<List<T>> GetAllAsync()
        {
            var list = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
            return list;
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var list = await _context.Set<T>()
                .AsNoTracking()
                .Where(filter)
                .ToListAsync();
            return list;
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector, OrderByType OrderByType = OrderByType.DESC)
        {
            var list = (OrderByType == OrderByType.DESC) ? await _context.Set<T>()
                .AsNoTracking()
                .OrderByDescending(keySelector)
                .Where(filter)
                .ToListAsync() :
                await _context.Set<T>()
                .AsNoTracking()
                .OrderBy(keySelector)
                .Where(filter)
                .ToListAsync();
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
