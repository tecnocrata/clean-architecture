using System;
using AutoMapper;

namespace VersioningService.Helper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.MicrofrontEnd, Core.Models.MicrofronEnd>();
        }
    }
}
