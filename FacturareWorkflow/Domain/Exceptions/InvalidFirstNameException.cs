using System;
using System.Runtime.Serialization;

namespace FacturareWorkflow.Domain.Exceptions
{
    [Serializable]
    internal class InvalidFirstNameException : Exception
    {
        public InvalidFirstNameException()
        {
        }

        public InvalidFirstNameException(string? message) : base(message)
        {
        }

        public InvalidFirstNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidFirstNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}