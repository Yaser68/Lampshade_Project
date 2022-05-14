using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using System;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            


            services.AddDbContext<ShopContext>(Options => Options.UseSqlServer(connectionString));
        }
    }
}
