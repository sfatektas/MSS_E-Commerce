using E_Commerce.DataAccess.Contexts;
using E_Commerce.DataAccess.Interfaces;
using E_Commerce.DataAccess.Repositories;
using E_Commerce.DataAccess.Repositories.Abstract;
using E_Commerce.DataAccess.Repositories.IdentitiyRepositories;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
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
        //Identities Repositories
        public AdminRepository GetAdminRepository() => new AdminRepository(_context);
        public CustomerRepository GetCustomerRepository() => new CustomerRepository(_context);
        public SupplierRepository GetSupplierRepository() => new SupplierRepository(_context);

        public ProductRepository GetProductRepository() => new ProductRepository(_context);
        public OrderRepository GetOrderRepository() => new OrderRepository(_context);
        public Repository<T> GetRepository<T>() where T : BaseEntity, IBaseEntity, new() => new Repository<T>(_context);
        public IdentityRepository<T> GetIdentityRepository<T>() where T : AppUser, new() => new IdentityRepository<T>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
