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
    public class OrderStatusTypeConfiguration : IEntityTypeConfiguration<OrderStatusType>
    {
        public void Configure(EntityTypeBuilder<OrderStatusType> builder)
        {
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(50);
        }
    }
}
