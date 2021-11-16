using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace VersioningService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            if (currentEnvironment?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
            {
                configBuilder.AddJsonFile($"appsettings.{currentEnvironment}.json", optional: false);
            }

            IConfigurationRoot config = configBuilder.Build();
            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Info($"{ApiConstants.FriendlyServiceName} starts running");
                CreateWebHostBuilder(args, config).Build().Run();
                logger.Info($"{ApiConstants.FriendlyServiceName} is stopped");
            }
            catch (System.Exception exception)
            {
                logger.Error(exception);
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args, IConfigurationRoot configuration) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
                    if (!(bool)(appSettings?.ByPassKeyVault))
                    {
                        KeyVaultCache.GetVaultSecrets(context, config);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();
    }
}
