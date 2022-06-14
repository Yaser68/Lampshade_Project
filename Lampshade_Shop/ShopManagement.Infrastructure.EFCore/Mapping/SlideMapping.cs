using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("slides");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Picture).IsRequired();
            builder.Property(x=>x.PictureAlt).IsRequired();
            builder.Property(x=>x.PictureTitle).IsRequired();
            builder.Property(x=>x.Heading);
            builder.Property(x => x.Title);
            builder.Property(x => x.Text);
            builder.Property(x => x.BtnText);
            builder.Property(x => x.Link);
            builder.Property(x => x.CreationDate);
        }
    }
}
