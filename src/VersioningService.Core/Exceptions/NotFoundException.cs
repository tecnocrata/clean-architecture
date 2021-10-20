using System;
using System.Runtime.Serialization;

namespace VersioningService.Core.Exceptions
{
    public class NotFoundException: DomainException
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception inner) : base(message, inner) { }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
