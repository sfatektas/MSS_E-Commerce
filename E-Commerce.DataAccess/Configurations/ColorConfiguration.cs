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
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(255);
            
            builder.HasData(new Color[]
            {
                new()
                {
                    Id = 1,
                    IsActive = true,
                    Defination = "Beyaz",
                },
                new()
                {
                    Id = 2,
                    IsActive = true,
                    Defination = "Siyah",
                },
                new()
                {
                    Id = 3,
                    IsActive = true,
                    Defination = "Gri",
                },
                new()
                {
                    Id = 4,
                    IsActive = true,
                    Defination = "Kahverengi",
                },
                new()
                {
                    Id = 5,
                    IsActive = true,
                    Defination = "Kırmızı",
                },
                new()
                {
                    Id = 6,
                    IsActive = true,
                    Defination = "Mavi",
                },
                new()
                {
                    Id = 7,
                    IsActive = true,
                    Defination = "Yeşil",
                },
                new()
                {
                    Id = 8,
                    IsActive = true,
                    Defination = "Sarı",
                },
                new()
                {
                    Id = 9,
                    IsActive = true,
                    Defination = "Turuncu",
                },
                new()
                {
                    Id = 10,
                    IsActive = true,
                    Defination = "Pembe",
                },
                new()
                {
                    Id = 11,
                    IsActive = true,
                    Defination = "Mor",
                },
                new()
                {
                    Id = 12,
                    IsActive = true,
                    Defination = "Lacivert",
                },
            });
        }
    }
}
