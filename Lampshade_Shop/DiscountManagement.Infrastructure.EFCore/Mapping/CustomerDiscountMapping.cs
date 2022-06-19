using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustmerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustmerDiscount> builder)
        {
            builder.ToTable("customerDiscounts");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.ProductId);
            builder.Property(x => x.DiscountRate);
            builder.Property(x => x.DiscountReason);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.CreationDate);

        }
    }
}
