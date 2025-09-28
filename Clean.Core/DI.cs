using Microsoft.Extensions.DependencyInjection;

namespace Clean.Core
{
    public static class DI
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
