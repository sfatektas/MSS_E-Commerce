using E_Commerce.Entities.EFCore;
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
    public class CustomerAddressesConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Town).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AddressDefination).IsRequired().HasMaxLength(150);
        }
    }
}
