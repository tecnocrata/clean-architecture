using System;
using Microsoft.EntityFrameworkCore;
using VersioningService.Infrastructure.Entities;

namespace VersioningService.Infrastructure.Context
{
    public class VersioningDbContext: DbContext
    {
        public VersioningDbContext(DbContextOptions<VersioningDbContext> options): base(options)
        {
        }

        public virtual DbSet<MicrofrontEnd> MicrofronEnds { get; set; }
    }
}
