using System;
namespace VersioningService.Core.Models
{
    public class MicrofronEnd
    {
        public Guid Id { get; set; } //Maybe this not?

        public string Name { get; set; }

        public string Version { get; set; }

        public string Url { get; set; }

        public DateTime PublishedAt { get; set; }
    }
}
