using System.Runtime.Serialization;

namespace BooksMVC.DAL.Exceptions
{
    internal class EntityNotExistsException : Exception
    {
        public EntityNotExistsException()
        {
        }

        public EntityNotExistsException(string? message) : base(message)
        {
        }

        public EntityNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
