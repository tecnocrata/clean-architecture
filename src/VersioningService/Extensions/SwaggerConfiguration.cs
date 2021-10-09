using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace VersioningService
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicrofronEndService", Version = "v1" });
            });

            return services;
        }
    }
}
