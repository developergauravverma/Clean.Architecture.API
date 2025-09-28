using Clean.Core.Interfaces;
using Clean.InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.InfraStructure
{
    public static class DI
    {
        public static IServiceCollection AddInfraStructureDI(this IServiceCollection services, IConfigurationManager config)
        {
            services.AddDbContext<Data.AppDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
