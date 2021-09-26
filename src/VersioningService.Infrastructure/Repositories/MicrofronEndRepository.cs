using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Models;
using VersioningService.Infrastructure.Context;

namespace VersioningService.Infrastructure.Repositories
{
    public class MicrofronEndRepository : IMicrofrontEndRepository
    {
        private readonly VersioningDbContext _dbContext;
        private readonly IMapper _mapper;

        public MicrofronEndRepository(VersioningDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            var mfes = await _dbContext.MicrofronEnds.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<MicrofronEnd>>(mfes);
        }

        public Task<MicrofronEnd> GetMicrofronEndById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
