using System;
using System.ComponentModel.DataAnnotations;

namespace VersioningService.Infrastructure.Entities
{
    public class MicrofrontEnd
    {
        public MicrofrontEnd()
        {
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Version { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime PublishedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
