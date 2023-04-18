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
    public class SupplierProductConfiguration : IEntityTypeConfiguration<SupplierProduct>
    {
        public void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.SupplierId,
                x.ProductId,
                x.SizeId,
                x.ColorId
            }).IsUnique(); //bir satıcı aynı ürünün , aynı renkteki , aynı bedendeki halini sadece 1 kere kayıt olarak geçebilir.
            //builder.Property(x => x.UnitPrice).HasMaxLength(10000000);
            builder.Property(x => x.CustomProductTitle).HasMaxLength(500);
            builder.Property(x => x.CustomProductDefination).HasMaxLength(500);

        }
    }
}
