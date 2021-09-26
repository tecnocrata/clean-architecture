using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Models;
using VersioningService.Infrastructure.Context;

namespace VersioningService.Infrastructure.Repositories
{
    public class MicrofronEndRepository : IMicrofrontEndRepository
    {
        private readonly VersioningDbContext _dbContext;

        public MicrofronEndRepository()
        {
        }

        public Task<bool> CreateMicrofronEnd(MicrofronEnd mfe)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMicrofrontEnd(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MicrofronEnd>> GetAllMicrofrontEnds()
        {
            throw new NotImplementedException();
        }

        public Task<MicrofronEnd> GetMicrofronEndById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
