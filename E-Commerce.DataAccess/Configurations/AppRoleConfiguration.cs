using E_Commerce.Entities.EFCore.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new List<AppRole>
            {
                new()
                {
                    Id= 1,
                    Name = "Admin",
                },
                 new()
                {
                    Id= 2,
                    Name = "Customer",
                },
                 new()
                {
                    Id= 3,
                    Name = "Supplier",
                }
            }); 
        }
    }
}
