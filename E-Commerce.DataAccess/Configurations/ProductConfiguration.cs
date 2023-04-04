using E_Commerce.Entities.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.BrandId,
                x.Name
            });
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Detail).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(200);
        }
    }
}
