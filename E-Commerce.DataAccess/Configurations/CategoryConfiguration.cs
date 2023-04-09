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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Defination).IsRequired();
            builder.Property(x => x.Defination).HasMaxLength(400);

            builder.HasData(new Category[]
            {
                new()
                {
                    Id = 1,
                    IsActive= true,
                    Defination = "TShirt",
                },                new()
                {
                    Id = 2,
                    IsActive= true,
                    Defination = "Pantalon",
                },                new()
                {
                    Id = 3,
                    IsActive= true,
                    Defination = "Ayakkabı",
                },                new()
                {
                    Id = 4,
                    IsActive= true,
                    Defination = "Gömlek",
                },                new()
                {
                    Id = 5,
                    IsActive= true,
                    Defination = "Bluz",
                },
            });
        }
    }
}
