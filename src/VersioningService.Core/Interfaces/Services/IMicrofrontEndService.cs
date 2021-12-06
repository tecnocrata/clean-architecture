using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VersioningService.Core.Models;

namespace VersioningService.Core.Interfaces.Services
{
    public interface IMicrofrontEndService
    {
        Task<IEnumerable<MicrofronEnd>> GetAllMicrofrontEnds();

        Task<MicrofronEnd> GetMicrofronEndById(Guid id);

        Task<MicrofronEnd> CreateMicrofronEnd(MicrofronEnd mfe);

        Task<bool> DeleteMicrofrontEnd(Guid id);

        Task<bool> UpdateMicrofrontEnd(Guid id, MicrofronEnd mfe);
    }
}
