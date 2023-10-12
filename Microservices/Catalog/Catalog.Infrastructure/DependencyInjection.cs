using Catalog.Application.Repositories;
using Catalog.Infrastructure.Database;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDBSettings"));

            services.AddSingleton<ICatalogContext, CatalogContext>();

            // REPOSITORIES STARTS HERE
                services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
                services.AddScoped<IBrandRepository, BrandRepository>();
                services.AddScoped<IProductRepository, ProductRepository>();
            // REPOSITORIES ENDS HERE

            return services;
        }
    }
}
