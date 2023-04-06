using E_Commerce.Entities.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Configurations
{
    public class SizeTypeConfiguration : IEntityTypeConfiguration<SizeType>
    {
        public void Configure(EntityTypeBuilder<SizeType> builder)
        {
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(400);
            //builder.HasMany(x => x.Sizes).WithOne(x => x.SizeType).HasForeignKey(x => x.SizeTypeId);

            builder.HasData(new SizeType[]
            {
                new()
                {
                    Id = 1,
                    Defination = "Üst Giyim",
                    IsActive = true,
                },
                new()
                {
                    Id = 2,
                    Defination = "Alt Giyim",
                    IsActive = true,
                },
                new()
                {
                    Id = 3,
                    Defination = "Ayak Numarası",
                    IsActive = true,
                }
            });
        }
    }
}
