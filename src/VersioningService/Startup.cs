using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VersioningService.Middlewares;

namespace VersioningService
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
            services.ConfigureCors();

            services.ConfigureDependencyInjection(Configuration);

            services.AddControllers();

            //services.ConfigureSwagger();
            services.ConfigureSwagger2();

            services.AddAutoMapper(typeof(Startup));

            services.AddRouting(options => options.LowercaseUrls = true);

            services.ConfigureHealthChecks(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // for testing only
                // app.UseHttpCodeAndLogMiddleware();
            }
            else
            {
                // For production
                app.UseHttpCodeAndLogMiddleware();
                app.UseHsts();
            }

            //app.ConfigureSwagger(provider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapHealthChecks("/health");
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                app.UseHealthChecksUI(delegate (Options options)
                {
                    options.UIPath = "/healthchek-ui";
                    options.AddCustomStylesheet("./healthchecks/custom.css");
                });
                // endpoints.MapHealthChecks("/health", new HealthCheckOptions() { Predicate = (_) => false });
                // endpoints.MapHealthChecks("/healthcheck", new HealthCheckOptions() { Predicate = (_) => false });
                // endpoints.MapHealthChecks("/probe/healthcheck", new HealthCheckOptions() { Predicate = (_) => false });
                // endpoints.MapHealthChecks("/probe/host", new HealthCheckOptions() { Predicate = (check) => check.Tags.Contains("host"), ResponseWriter = ResponseWritters.HostProbeWriter });
                // endpoints.MapHealthChecks("/activecheck", new HealthCheckOptions() { Predicate = (check) => check.Tags.Contains("host"), ResponseWriter = ResponseWritters.HostProbeWriter });
                // endpoints.MapHealthChecks("/probe/ready", new HealthCheckOptions() { Predicate = (check) => check.Tags.Contains("ready") });
                // endpoints.MapHealthChecks("/probe/healthreport", new HealthCheckOptions() { Predicate = (check) => check.Tags.Contains("ready"), ResponseWriter = ResponseWritters.HealthReportWriter });
            });

            app.ConfigureSwagger(provider);
            //app.ConfigureSwagger2(provider);

        }
    }
}
