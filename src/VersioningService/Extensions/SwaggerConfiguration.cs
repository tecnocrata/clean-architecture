using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                // options.ApiVersionReader = new Microsoft.AspNetCore.Mvc.Versioning.UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // var serviceDescripttion = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ServiceDescription.md"));
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                IApiVersionDescriptionProvider provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
                // c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicrofronEndService", Version = "v1", Description = serviceDescripttion });
                string xmlFile = $"{typeof(SwaggerConfiguration).Assembly.GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
                c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
            });

            return services;
        }

        // Previous name: ConfigureSwagger
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            // app.UseSwagger(options => options.RouteTemplate = "swagger/"+ApiConstants.ServiceName+"/{documentName}/swagger.json");
            app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(c =>
            {
                // c.RoutePrefix = $"swagger/{ApiConstants.ServiceName}";
                // Build a swagger endpoint for each discovered API version
                foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                {
                    // c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicrofrontEndService v1")
                    c.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
            return app;
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            string serviceDescription = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ServiceDescription.md"));
            var info = new OpenApiInfo
            {
                Title = $"{ApiConstants.FriendlyServiceName} API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = serviceDescription
            };
            if (description.IsDeprecated)
            {
                info.Description += $"{Environment.NewLine} This API version has been deprecated";
            }
            return info;
        }
    }

}
