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
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasData(new UserType[]
            {
                new UserType
                {
                    Id = 1 ,
                    Defination = "Admin",
                    IsActive = true
                },
                new UserType
                {
                    Id =2 ,
                    Defination = "Customer",
                    IsActive = true
                },
                new UserType
                {
                    Id = 3 ,
                    Defination = "Supplier",
                    IsActive = true
                },
            });
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(400);
        }
    }
}
