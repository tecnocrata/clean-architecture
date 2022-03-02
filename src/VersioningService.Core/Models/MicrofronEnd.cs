using System;
namespace VersioningService.Core.Models
{
    /// <summary>
    /// This an domain entity and an aggregate object at the same time
    /// </summary>
    public class MicrofronEnd // This should inherits from AggregateRoot
    {
        // We should make all these properties private!!!
        public Guid Id { get; set; } // Maybe this not?

        public string Name { get; set; }

        public string Version { get; set; }

        // public MfeUrl Url { get; set; }
        public string Url { get; set; }

        public DateTime PublishedAt { get; set; }

        public MicrofronEnd()
        {

        }
        /// <summary>
        /// Named Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MicrofronEnd Create(MfeId id, MfeUrl url)
        {
            return new MicrofronEnd();
        }
    }
}
