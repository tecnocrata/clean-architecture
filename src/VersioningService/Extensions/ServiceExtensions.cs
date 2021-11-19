using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using VersioningService.HealthChecks;

namespace VersioningService
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO: Please review more healthchecks here: http://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
            // https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
            // https://medium.com/swlh/how-to-implement-healthcheck-api-in-microservices-architecture-with-net-core-a5882369b016
            services.AddHealthChecks()
            //.AddMongoDb(configuration["ConnectionStrings:versioningdb"], name: "MongoDB", tags: new[] { "Versioning", "Database" }, failureStatus: HealthStatus.Unhealthy)
            .AddCheck<RemoteHealthCheck>("Remote Endpoints Health Check", failureStatus: HealthStatus.Unhealthy) // when we call external APIs
            .AddCheck<MemoryHealthCheck>("Memory Health Check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Versioning Service" }) // check memory health based on allocation memory
            .AddUrlGroup(new Uri($"https://localhost:19726/api/v1/heartbeat/ping"), name: "Base URL", failureStatus: HealthStatus.Unhealthy);// This could be implemented by group of APIs

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10); // time in seconds between checks
                opt.MaximumHistoryEntriesPerEndpoint(60); // maximum history of checks
                opt.SetApiMaxActiveRequests(1); // concurrent api requests
                opt.AddHealthCheckEndpoint("Versioning API", "/health");
            })
            .AddInMemoryStorage();
        }
    }
}
