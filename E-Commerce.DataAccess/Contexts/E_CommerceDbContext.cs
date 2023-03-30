using E_Commerce.DataAccess.Configurations;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Contexts
{
    public class E_CommerceDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public E_CommerceDbContext(DbContextOptions<E_CommerceDbContext> options) : base(options)
        {}
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Entities.EFCore.Identities.Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomersAddresses { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatusType> OrderStatusTypes { get; set; }
        public DbSet<PriceHistory> PriceHistory { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsInStock> ProductsInStocks { get; set; }
        public DbSet<ProductsVisitor> ProductsVisitors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SizeType> SizeTypes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Entities.EFCore.Identities.Supplier> Suppliers { get; set; }
        public DbSet<SupplierAddingProduct> SuppliersAddingProducts { get; set; }
        public DbSet<SupplierProduct> SuppliersProducts { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
