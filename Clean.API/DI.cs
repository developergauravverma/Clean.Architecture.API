using Clean.Application;
using Clean.InfraStructure;

namespace Clean.API
{
    public static class DI
    {
        public static IServiceCollection AddAPIDI(this IServiceCollection services, IConfigurationManager config)
        {
            services.AddApplicationDI().AddInfraStructureDI(config);
            return services;
        }
    }
}
