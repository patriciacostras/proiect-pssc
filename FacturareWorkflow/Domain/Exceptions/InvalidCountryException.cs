using System;
using System.Runtime.Serialization;

namespace FacturareWorkflow.Domain.Exceptions
{
    [Serializable]
    internal class InvalidCountryException : Exception
    {
        public InvalidCountryException()
        {
        }

        public InvalidCountryException(string? message) : base(message)
        {
        }

        public InvalidCountryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCountryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}