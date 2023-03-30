using E_Commerce.Common.Enums;
using E_Commerce.Entities.EFCore;
using E_Commerce.Entities.EFCore.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasDiscriminator<int>("DiscriminatorUserType")
                .HasValue<AppUser>(0)
                .HasValue<Admin>((int)AppUserType.Admin)
                .HasValue<Supplier>((int)AppUserType.Supplier)
                .HasValue<Customer>((int)AppUserType.Customer);
        }
    }
}
