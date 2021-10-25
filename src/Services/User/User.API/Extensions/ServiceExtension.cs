using Microsoft.Extensions.DependencyInjection;
using User.Infrastructure.Data.Seed;

namespace User.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDbInitializer(this IServiceCollection services)
        {
            services.AddTransient<IDbInitializer, DbInitializer>();

            return services;
        }
    }
}