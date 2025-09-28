using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application
{
    public static class DI
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DI).Assembly));
            return services;
        }
    }
}
