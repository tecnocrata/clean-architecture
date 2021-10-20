using System;
using System.Runtime.Serialization;

namespace VersioningService.Core.Exceptions
{
    public class ValidationException: DomainException
    {
        public ValidationException() : base()
        {
        }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception inner) : base(message, inner) { }

        public ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
