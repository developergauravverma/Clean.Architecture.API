using Clean.Core.Interfaces;
using Clean.Core.Options;
using Clean.InfraStructure.Repository;
using Clean.InfraStructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Clean.InfraStructure
{
    public static class DI
    {
        public static IServiceCollection AddInfraStructureDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Data.AppDBContext>((provider,options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddHttpClient<IHttpClientServices, HttpClientServices>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExternalVenderRepository, ExternalVenderRepository>();
            return services;
        }
    }
}
