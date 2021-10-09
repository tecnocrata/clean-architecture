using System;
namespace VersioningService.AppSettings
{
    public class AppSettings
    {
        public AppSettings()
        {
        }

        public string KeyVaultName { get; set; }
        public bool ByPassKeyVault { get; set; }
    }
}
