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
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MicrofronEnd> CreateMicrofronEnd(MicrofronEnd mfe)
        {
            var dbMfe = _mapper.Map<Entities.MicrofrontEnd>(mfe);
            dbMfe.PublishedAt = DateTime.Now;
            await _dbContext.MicrofronEnds.AddAsync(dbMfe);
            await _dbContext.SaveChangesAsync();
            return mfe;
        }

        public async Task<bool> DeleteMicrofrontEnd(Guid id)
        {
            var dbMfe = await _dbContext.MicrofronEnds.FindAsync(id); //.SingleOrDefaultAsync(m => m.Id == id);
            if (dbMfe != null)
            {
                _dbContext.MicrofronEnds.Remove(dbMfe);
                // Commit the transaction
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<MicrofronEnd>> GetAllMicrofrontEnds()
        {
            var mfes = await _dbContext.MicrofronEnds.ToListAsync().ConfigureAwait(false);
            //TODO: What about if mfes is null?
            return _mapper.Map<IEnumerable<MicrofronEnd>>(mfes);
        }

        public async Task<MicrofronEnd> GetMicrofronEndById(Guid id)
        {
            var mfe = await _dbContext.MicrofronEnds.FindAsync(id);
            if (mfe != null) return _mapper.Map<MicrofronEnd>(mfe);
            return null;
        }

        public async Task<bool> UpdateMicrofronEnd(Guid id, MicrofronEnd mfe)
        {
            var dbMfe = await _dbContext.MicrofronEnds.FindAsync(id); //.SingleOrDefaultAsync(m => m.Id == id);
            if (dbMfe == null || dbMfe.Id != id)
            {
                return false;
            }
            if (mfe != null)
            {
                dbMfe.Name = mfe.Name;
                dbMfe.Url = mfe.Url.Value;
                dbMfe.Version = mfe.Version;
                dbMfe.PublishedAt = DateTime.Now;
                _dbContext.MicrofronEnds.Update(dbMfe);
                //Commit the transaction
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
