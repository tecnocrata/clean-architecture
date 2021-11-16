using System;
namespace VersioningService
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
