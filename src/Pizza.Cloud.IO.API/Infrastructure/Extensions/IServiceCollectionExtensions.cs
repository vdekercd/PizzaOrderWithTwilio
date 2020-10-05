using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Pizza.Cloud.IO.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10);
                    });

            })
                .AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza.Cloud.IO.API", Version = GetVersionForSwagger() });
            });
            return services;
        }

        private static string GetVersionForSwagger()
        {
            var version = typeof(Startup).Assembly.GetName().Version;
            return $"v{version.Major}.{version.Minor}";
        }
    }
}
