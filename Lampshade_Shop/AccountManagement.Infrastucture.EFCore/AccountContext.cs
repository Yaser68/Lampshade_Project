using AccountManagement.Infrastucture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastucture.EFCore
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountManagement.Domain.AccountAgg.Account> accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
