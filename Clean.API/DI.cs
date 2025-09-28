using Clean.Application;
using Clean.Core;
using Clean.InfraStructure;

namespace Clean.API
{
    public static class DI
    {
        public static IServiceCollection AddAPIDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddApplicationDI().AddInfraStructureDI(config).AddCoreDI(config);
            return services;
        }
    }
}
