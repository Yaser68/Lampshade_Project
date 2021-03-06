using Account.Application;
using Account.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastucture.EFCore;
using AccountManagement.Infrastucture.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddDbContext<AccountContext>(Options => Options.UseSqlServer(connectionString));
        }
    }
}
