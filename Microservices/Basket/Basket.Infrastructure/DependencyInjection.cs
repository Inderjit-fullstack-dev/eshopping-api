using Basket.Application.Repositories;
using Basket.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {

            // REPOSITORIES STARTS HERE
            services.AddScoped<IBasketRepository, BasketRepository>();
            // REPOSITORIES ENDS HERE

            return services;
        }
    }
}
