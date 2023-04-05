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

            builder.HasData(new SizeType[]
            {
                new()
                {
                    Id = 1,
                    Defination = "Small",
                    IsActive = true,
                },
                new()
                {
                    Id = 2,
                    Defination = "Medium",
                    IsActive = true,
                },
                new()
                {
                    Id = 3,
                    Defination = "Large",
                    IsActive = true,
                },
                new()
                {
                    Id = 4,
                    Defination = "XLarge",
                    IsActive = true,
                },
                new()
                {
                    Id = 5,
                    Defination = "XXLARGE",
                    IsActive = true,
                },
            });
        }
    }
}
