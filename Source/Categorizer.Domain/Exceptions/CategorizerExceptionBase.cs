namespace Categorizer.Domain.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CategorizerExceptionBase : Exception
    {
        public CategorizerExceptionBase()
        {
        }

        public CategorizerExceptionBase(string message)
            : base(message)
        {
        }

        public CategorizerExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CategorizerExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}