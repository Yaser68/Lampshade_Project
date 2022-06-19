using CustomerDiscount.Application;
using CustomerDiscount.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            

            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddDbContext<DiscountContext>(Options => Options.UseSqlServer(connectionString));
        }
    }
}
