using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Pizza.Cloud.IO.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
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
