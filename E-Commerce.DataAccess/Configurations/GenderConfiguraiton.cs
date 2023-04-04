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
    public class GenderConfiguraiton : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(new Gender[]
            {
                new Gender
                {
                    Id= 1,
                    Defination = "Erkek",
                    IsActive = true
                },
                new Gender
                {
                    Id= 2,
                    Defination = "Kadın",
                    IsActive = true
                },
                new Gender
                {
                    Id= 3,
                    Defination = "Belirtmek İstemiyorum",
                    IsActive = true
                },
            });

            builder.Property(x=>x.Defination).IsRequired().HasMaxLength(20);
        }
    }
}
