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
    public class SiteOptionConfiguration : IEntityTypeConfiguration<SiteOption>
    {
        public void Configure(EntityTypeBuilder<SiteOption> builder)
        {
            builder.Property(x=>x.Logo).IsRequired().HasMaxLength(250);
            builder.Property(x=>x.Slogan).IsRequired().HasMaxLength(350);
            builder.Property(x=>x.FacebookLink).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.TwitterLink).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.InstagramLink).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.PhoneNumber).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Adress).IsRequired().HasMaxLength(500);
        }
    }
}
