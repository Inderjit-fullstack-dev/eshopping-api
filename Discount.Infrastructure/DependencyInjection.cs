using Discount.Application.Repositories;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Discount.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            // REPOSITORIES STARTS HERE
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            // REPOSITORIES ENDS HERE

            return services;
        }
    }
}
