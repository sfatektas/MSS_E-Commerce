using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.DataAccess.Repositories.Abstract;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.UnitOfWorks
{
    public class Uow : IUow
    {
        private readonly E_CommerceDbContext _context;

        public Uow(E_CommerceDbContext context)
        {
            _context = context;
        }

        public Repository<T> GetRepository<T>() where T : BaseEntity, IBaseEntity, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
