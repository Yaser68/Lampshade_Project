using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastucture.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<AccountManagement.Domain.AccountAgg.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.AccountAgg.Account> builder)
        {
            builder.ToTable("accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.UserName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ProfilePhoto).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(20);
        }
    }
}
