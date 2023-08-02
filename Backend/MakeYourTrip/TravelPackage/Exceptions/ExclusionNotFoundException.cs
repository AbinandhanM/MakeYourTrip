using System.Runtime.Serialization;

namespace TravelPackage.Exceptions
{
    [Serializable]
    internal class ExclusionNotFoundException : Exception
    {
        public ExclusionNotFoundException()
        {
        }

        public ExclusionNotFoundException(string? message) : base(message)
        {
        }

        public ExclusionNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExclusionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}