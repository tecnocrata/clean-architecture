using System;
using VersioningService.Core.Models;
using Xunit;

namespace VersioningService.Application.Tests
{
    public class MfeCreatorTest: MfeUnitTestCase
    {
        public MfeCreatorTest()
        {
        }

        [Fact]
        public void ShouldSaveMfe()
        {
            var creator = new MfeCreator(repository);
            MicrofronEnd mfe  = null; //MfeStub.CreateRandom(); // VideoStub.random
            //creator.Create()
            //Verify that repository.save was called with mfe
            repositoryShouldSaveMfe(mfe);
            //assert.shouldcall (repository.save).with(mfe)
        }
    }
}
