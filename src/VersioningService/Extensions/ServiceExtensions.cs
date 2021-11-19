﻿using System;
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
            services.AddHealthChecks()
            //.AddMongoDb(configuration["ConnectionStrings:versioningdb"], name: "MongoDB", tags: new[] { "Versioning", "Database" }, failureStatus: HealthStatus.Unhealthy)
            .AddCheck<RemoteHealthCheck>("Remote Endpoints Health Check", failureStatus: HealthStatus.Unhealthy) // when we call external APIs
            .AddCheck<MemoryHealthCheck>("Memory Health Check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Versioning Service" }); // 

        }
    }
}
