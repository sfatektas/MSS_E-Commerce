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
    public class SliderItemConfiguration : IEntityTypeConfiguration<SliderItem>
    {
        public void Configure(EntityTypeBuilder<SliderItem> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.SubTitle).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ButtonText).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ButtonLink).IsRequired().HasMaxLength(300);

        }
    }
}
