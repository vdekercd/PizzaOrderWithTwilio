using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza.Cloud.IO.Domain.Interfaces;
using Pizza.Cloud.IO.Infrastructure;
using Pizza.Cloud.IO.Infrastructure.Extensions;

namespace Pizza.Cloud.IO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger()
                .AddDataAccessServices(Configuration.GetConnectionString("AzureDatabase"))
                .AddControllers();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureDevelopment(env)
                .UseCustomSwagger()
                .UseController();
        }
    }
}
