using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockAppG7C324.Core.Application.Interfaces.Repositories;
using StockAppG7C324.Infrastructure.Persistence.Contexts;
using StockAppG7C324.Infrastructure.Persistence.Repositories;

namespace StockAppG7C324.Infrastructure.Persistence
{
    // Decorator pattern - Extension methods
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration config) 
        {
            #region Database Connection
            if (config.GetValue<bool>("UseDatabaseInMemory"))
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationContext>(opt => 
                                            opt.UseSqlServer(connectionString,
                                            m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories DI
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion
        }
    }
}
