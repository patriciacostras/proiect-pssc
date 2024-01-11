using System;
using System.Runtime.Serialization;

namespace FacturareWorkflow.Domain.Exceptions
{
    [Serializable]
    internal class InvalidStreetException : Exception
    {
        public InvalidStreetException()
        {
        }

        public InvalidStreetException(string? message) : base(message)
        {
        }

        public InvalidStreetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidStreetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}