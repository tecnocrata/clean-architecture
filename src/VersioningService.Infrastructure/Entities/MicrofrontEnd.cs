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
        public string Version { get; set; }
    }
}
