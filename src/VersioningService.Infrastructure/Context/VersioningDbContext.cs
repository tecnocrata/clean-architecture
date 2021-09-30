using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VersioningService.Infrastructure.Entities;

namespace VersioningService.Infrastructure.Context
{
    public class VersioningDbContext: DbContext
    {
        public VersioningDbContext(DbContextOptions<VersioningDbContext> options): base(options)
        {
            SeedData();
        }

        public virtual DbSet<MicrofrontEnd> MicrofronEnds { get; set; }

        private void SeedData()
        {
            var mfes = new List<MicrofrontEnd>()
            {
                new MicrofrontEnd(){Id= Guid.NewGuid(), Name="hours-editor-vue", Url="http://localhost:6002/remoteEntry.js", Version="1.0.1", CreatedBy="Enrique", PublishedAt= DateTime.Now},
                new MicrofrontEnd(){Id= Guid.NewGuid(), Name="snippet-editor-angular11", Url="http://localhost:4203/remoteEntry.js", Version="1.1.0", CreatedBy="Enrique", PublishedAt= DateTime.Now},
                new MicrofrontEnd(){Id= Guid.NewGuid(), Name="snippet-editor-angular11", Url="http://localhost:42031/remoteEntry.js", Version="2.0.0", CreatedBy="Enrique", PublishedAt= DateTime.Now},
                new MicrofrontEnd(){Id= Guid.NewGuid(), Name="hours-editor-vue", Url="http://localhost:60021/remoteEntry.js", Version="1.2.0", CreatedBy="Enrique", PublishedAt= DateTime.Now}
            };
            MicrofronEnds.AddRange(mfes);
            SaveChanges();
        }
    }
}
