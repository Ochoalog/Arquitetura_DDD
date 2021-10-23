using Api.CrossCutting.DependencyInjection;
using Api.Domain.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace application
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
            ConfigureService.ConfigureDependencyService(services);
            ConfigureRepository.ConfigureDependencyRepository(services);
            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguaration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfiguration"))
                    .Configure(tokenConfiguaration);
            services.AddSingleton(tokenConfiguaration);


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api DDD",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Vitor Macedo Ochoa",
                        Email = "vitor-ochoa@uergs.edu.br"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api DDD");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
