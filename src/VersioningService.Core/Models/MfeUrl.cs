using System;
namespace VersioningService.Core.Models
{
    /// <summary>
    /// Value Object for Microfront end URL
    /// </summary>
    public class MfeUrl
    {
        private string url;

        public MfeUrl(string url)
        {
            this.GuardValidUrl(url);
            this.url = url;
        }

        private void GuardValidUrl(string url)
        {
            //if (!Regexp.IsUrl(url))
            //{
            //    throw new ArgumentException($"The url {url} is not well formed");
            //}
            return;
        }

        public string Value
        {
            get { return this.url; }
            // private set;
        }
    }
}
