using Microsoft.Extensions.DependencyInjection;

namespace Discount.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(DependencyInjection));

            // REPOSITORIES STARTS HERE
            // REPOSITORIES ENDS HERE

            return services;
        }
    }
}
