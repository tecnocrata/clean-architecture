using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Models;

namespace VersioningService.Core.Services
{
    public class MicrofrontEndService : IMicrofrontEndService
    {
        private readonly IMicrofrontEndRepository _mfeRepository;
        private readonly ILogger<MicrofrontEndService> logger;

        public MicrofrontEndService(IMicrofrontEndRepository mfeRepository, ILogger<MicrofrontEndService> logger)
        {
            _mfeRepository = mfeRepository ?? throw new ArgumentNullException(nameof(mfeRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<MicrofronEnd> CreateMicrofronEnd(MicrofronEnd mfe)
        {
            return await _mfeRepository.CreateMicrofronEnd(mfe);
        }

        public async Task<bool> DeleteMicrofrontEnd(Guid id)
        {
            return await _mfeRepository.DeleteMicrofrontEnd(id);
        }

        public async Task<IEnumerable<MicrofronEnd>> GetAllMicrofrontEnds()
        {
            try
            {
                // throw new ArgumentNullException();
                return await _mfeRepository.GetAllMicrofrontEnds().ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Error while trying to call GetAllMicrofrontends in the service class, error = {ex}");
                throw;
            }
        }

        public async Task<MicrofronEnd> GetMicrofronEndById(Guid id)
        {
            return await _mfeRepository.GetMicrofronEndById(id);
        }

        public async Task<bool> UpdateMicrofrontEnd(Guid id, MicrofronEnd mfe)
        {
            return await _mfeRepository.UpdateMicrofronEnd(id, mfe);
        }
    }
}
