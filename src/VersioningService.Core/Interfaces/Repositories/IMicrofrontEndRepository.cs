using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VersioningService.Core.Models;

namespace VersioningService.Core.Interfaces.Repositories
{
    public interface IMicrofrontEndRepository
    {
        Task<IEnumerable<MicrofronEnd>> GetAllMicrofrontEnds();

        Task<MicrofronEnd> GetMicrofronEndById(Guid id);

        Task<bool> CreateMicrofronEnd(MicrofronEnd mfe);

        Task<bool> DeleteMicrofrontEnd(Guid id);
    }
}
