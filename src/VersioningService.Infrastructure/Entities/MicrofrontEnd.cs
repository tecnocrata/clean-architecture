using System;
using System.ComponentModel.DataAnnotations;

namespace VersioningService.Infrastructure.Entities
{
    /// <summary>
    /// This is a DataBase model, it is tied to the ORM and DB particularities
    /// </summary>
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
