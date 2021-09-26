using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Models;

namespace VersioningService.Core.Services
{
    public class MicrofrontEndService: IMicrofrontEndService
    {
        private readonly IMicrofrontEndRepository _mfeRepository;

        public MicrofrontEndService(IMicrofrontEndRepository mfeRepository)
        {
            _mfeRepository = mfeRepository?? throw new ArgumentNullException(nameof(mfeRepository));
        }

        public Task<bool> CreateMicrofronEnd(MicrofronEnd mfe)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMicrofrontEnd(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MicrofronEnd>> GetAllMicrofrontEnds()
        {
            return await _mfeRepository.GetAllMicrofrontEnds().ConfigureAwait(false);
        }

        public Task<MicrofronEnd> GetMicrofronEndById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
