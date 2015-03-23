namespace Categorizer.Domain.Exceptions
{
    public class ValidationException : CategorizerExceptionBase
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}