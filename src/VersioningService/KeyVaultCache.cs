using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace VersioningService
{
    public class KeyVaultCache
    {
        public static string BaseUri { get; set; }

        private static Dictionary<string, string> SecretsCache = new Dictionary<string, string>();
        /// <summary>
        /// Also known as GetAzureKeyValueSecrets
        /// </summary>
        /// <param name="context"></param>
        /// <param name="config"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void GetVaultSecrets(HostBuilderContext context, IConfigurationBuilder config)
        {
            //throw new NotImplementedException();
            var builtConfig = config.Build();
            var keyVaultName = builtConfig[$"AppSettings:KeyVaultName"];
            // BaseUri = $"https://{keyVaultName}.vault.azure.net";
            // var secretClient = new SecretClient(new Uri(BaseUri), new DefaultAzureCredential());
            // config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
        }

        public static string GetCachedSecret(string secretName)
        {
            if (!SecretsCache.ContainsKey(secretName))
            {
                var secret = KeyVaultClientGetSecret(secretName);
                SecretsCache.Add(secretName, secret);
                return secret;
            }
            return SecretsCache[secretName];
        }

        private static string KeyVaultClientGetSecret(string secretName)
        {
            // This method fakes the real implementation that would retrieve from AWS/Azure
            switch (secretName)
            {
                // case "prod-versioning-db-connection-string": return "Server=localhost;Database=versioningdb;Integrated Security=true;";
                case "versioning-db-connection-string": return "Server=localhost;Database=versioningdb;Integrated Security=true;";
                default: return "";
            }
        }
    }

    public static class GetSecret
    {
        public static string VersioningConnectionString() => KeyVaultCache.GetCachedSecret($"{KeyVaultKeys.VersioningConnectionString}");
    }

}
