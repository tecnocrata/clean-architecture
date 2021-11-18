
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VersioningService.HealthChecks
{
    public class RemoteHealthCheck : IHealthCheck
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RemoteHealthCheck(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync("https://api.ipify.org");
                if (response.IsSuccessStatusCode)
                {
                    return HealthCheckResult.Healthy("Remote Endpoints are healthy");
                }
                return HealthCheckResult.Unhealthy("Remote Endpoints are unhealthy");
            }
        }
    }
}