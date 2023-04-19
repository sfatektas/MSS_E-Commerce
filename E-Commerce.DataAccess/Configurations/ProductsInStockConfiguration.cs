using E_Commerce.Entities.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Configurations
{
    public class ProductsInStockConfiguration : IEntityTypeConfiguration<ProductsInStock>
    {
        public void Configure(EntityTypeBuilder<ProductsInStock> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SupplierProductId);
            builder.Property(x=>x.IsActive).HasDefaultValue(true);  
        }
    }
}
