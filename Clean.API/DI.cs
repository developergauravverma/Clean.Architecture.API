using Clean.Application;
using Clean.Core;
using Clean.InfraStructure;

namespace Clean.API
{
    public static class DI
    {
        public static IServiceCollection AddAPIDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            services.AddApplicationDI().AddInfraStructureDI(config).AddCoreDI(config);
            return services;
        }

        public static IApplicationBuilder AddAPIDI(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
            return app;
        }
    }
}
