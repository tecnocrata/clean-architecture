using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Services;
using VersioningService.Infrastructure.Context;
using VersioningService.Infrastructure.Repositories;

namespace VersioningService
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            // var options = new DbContextOptionsBuilder<VersioningDbContext>()
            // .UseInMemoryDatabase(databaseName: "DiagAc2Tests")
            // .Options;
            // services.AddDbContext<VersioningDbContext>(opts => opts.UseInMemoryDatabase("MemInDB")); // This is just a workaround for using in-memory storage temporaly

            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
            string connectionString = string.Empty;
            if ((bool)appSettings?.ByPassKeyVault)
            {
                connectionString = configuration.GetConnectionString("versioningdb");
            }
            else
            {
                connectionString = GetSecret.VersioningConnectionString();
            }
            services.AddDbContext<VersioningDbContext>(optionsAction: opt => opt.UseSqlServer(connectionString), contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IMicrofrontEndService, MicrofrontEndService>();
            services.AddScoped<IMicrofrontEndRepository, MicrofronEndRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
