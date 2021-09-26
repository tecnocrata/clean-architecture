using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Models;

namespace VersioningService.Core.Services
{
    public class MicrofrontEndService: IMicrofrontEndService
    {
        public MicrofrontEndService()
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
