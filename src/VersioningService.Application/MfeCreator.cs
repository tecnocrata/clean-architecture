using System;
using VersioningService.Core.Interfaces.Repositories;
using VersioningService.Core.Models;

namespace VersioningService.Application
{
    public class MfeCreator
    {
        private IMicrofrontEndRepository repository;

        public MfeCreator(IMicrofrontEndRepository repository) //, IDomainEventPublisher publisher //Estos son los puertos
        {
            this.repository = repository;
        }

        public void Create (MfeId id, MfeUrl url) { // more params are needed
            var mfe = MicrofronEnd.Create(id, url);
            //this.repository.Save(mfe);
            //this.publisher.Publish(mfe.pullDomainEvents());

        }
    }
}
