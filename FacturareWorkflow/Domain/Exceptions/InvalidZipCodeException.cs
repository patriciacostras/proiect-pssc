using System;
using System.Runtime.Serialization;

namespace FacturareWorkflow.Domain.Exceptions
{
    [Serializable]
    internal class InvalidZipCodeException : Exception
    {
        public InvalidZipCodeException()
        {
        }

        public InvalidZipCodeException(string? message) : base(message)
        {
        }

        public InvalidZipCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidZipCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}