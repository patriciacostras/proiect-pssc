using System;
using System.Runtime.Serialization;

namespace FacturareWorkflow.Domain.Exceptions
{
    [Serializable]
    internal class InvalidLastNameException : Exception
    {
        public InvalidLastNameException()
        {
        }

        public InvalidLastNameException(string? message) : base(message)
        {
        }

        public InvalidLastNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidLastNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}