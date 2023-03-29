using E_Commerce.Entities.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Contexts
{
    public class E_CommerceDbContext: DbContext
    {
        public E_CommerceDbContext(DbContextOptions<E_CommerceDbContext> options) : base(options)
        {
            
        }

        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAddress> CustomersAddresses { get; set; }
        DbSet<FavoriteProduct> FavoriteProducts { get; set;}
        DbSet<Gender> Genders { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<OrderStatusType> OrderStatusTypes { get; set; }
        DbSet<PriceHistory> PriceHistory { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<ProductsInStock> ProductsInStocks { get; set; }
        DbSet<ProductsVisitor> ProductsVisitors { get; set;}
        DbSet<Size> Sizes { get; set; }
        DbSet<SizeType> SizeTypes { get; set; }
        DbSet<Slider>   Sliders { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<SupplierAddingProduct> SuppliersAddingProducts { get; set;}
        DbSet<SupplierProduct> SuppliersProductsProducts { get; set;}
        DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
