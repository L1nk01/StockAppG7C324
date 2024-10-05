using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockAppG7C324.Core.Application.Interfaces.Repositories;
using StockAppG7C324.Core.Application.Interfaces.Services;
using StockAppG7C324.Core.Application.Services;

namespace StockAppG7C324.Infrastructure.Persistence
{
    // Decorator pattern - Extension methods
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services) 
        {
            #region Services DI
            services.AddTransient<IProductService, ProductService>();
            #endregion
        }
    }
}
