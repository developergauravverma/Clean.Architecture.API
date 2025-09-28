using Clean.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Core
{
    public static class DI
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ConnectionStringOptions>(config.GetSection(key: ConnectionStringOptions.SectionName));
            return services;
        }
    }
}
