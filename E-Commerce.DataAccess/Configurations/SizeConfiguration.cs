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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(x=>x.Value).IsRequired().HasMaxLength(200);
            builder.HasData(new List<Size>
            {
                  new Size()
                    {
                        Id= 1,
                        SizeTypeId = 1,
                        Value = "Small"
                    },
                    new Size()
                    {
                        Id= 2,
                        SizeTypeId = 1,
                        Value = "Medium"
                    },
                    new Size()
                    {
                        Id= 3,
                        SizeTypeId = 1,
                        Value = "Large"
                    },
                    new Size()
                    {
                        Id= 4,
                        SizeTypeId = 1,
                        Value = "XXL"
                    },
                    new Size()
                    {
                        Id= 5,
                        SizeTypeId = 1,
                        Value = "XXXL"
                    },
                    new Size()
                    {
                        Id= 6,
                        SizeTypeId = 2,
                        Value = "29 30"
                    },
                    new Size()
                    {
                        Id= 7,
                        SizeTypeId = 2,
                        Value = "29 31"
                    },
                    new Size()
                    {
                        Id= 8,
                        SizeTypeId = 2,
                        Value = "29 32"
                    },
                    new Size()
                    {
                        Id= 9,
                        SizeTypeId = 2,
                        Value = "30 31"
                    },
                    new Size()
                    {
                        Id= 10,
                        SizeTypeId = 2,
                        Value = "30 32"
                    },
                    new Size()
                    {
                        Id= 11,
                        SizeTypeId = 3,
                        Value = "36"
                    },
                    new Size()
                    {
                        Id= 12,
                        SizeTypeId = 3,
                        Value = "37"
                    },
                    new Size()
                    {
                        Id= 13,
                        SizeTypeId = 3,
                        Value = "38"
                    },
                    new Size()
                    {
                        Id= 14,
                        SizeTypeId = 3,
                        Value = "39"
                    },
                    new Size()
                    {
                        Id= 15,
                        SizeTypeId = 3,
                        Value = "40"
                    },
                    new Size()
                    {
                        Id= 16,
                        SizeTypeId = 3,
                        Value = "41"
                    },
                    new Size()
                    {
                        Id= 17,
                        SizeTypeId = 3,
                        Value = "41.5"
                    },
                    new Size()
                    {
                        Id= 18,
                        SizeTypeId = 3,
                        Value = "42"
                    },
                    new Size()
                    {
                        Id= 19,
                        SizeTypeId = 3,
                        Value = "42.5"
                    },
                    new Size()
                    {
                        Id= 20,
                        SizeTypeId = 3,
                        Value = "43"
                    }
            });
        }
    }
}
