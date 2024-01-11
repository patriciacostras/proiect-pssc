using System;
using System.Runtime.Serialization;

namespace FacturareWorkflow.Domain.Exceptions
{
    [Serializable]
    internal class InvalidCityException : Exception
    {
        public InvalidCityException()
        {
        }

        public InvalidCityException(string? message) : base(message)
        {
        }

        public InvalidCityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}