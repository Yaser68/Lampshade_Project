using Inventory.Application.Contract.Inventory;
using InventoryManagement.Application;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {


            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddDbContext<InventoryContext>(Options => Options.UseSqlServer(connectionString));
        }
    }
}
