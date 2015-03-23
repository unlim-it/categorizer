namespace Categorizer.Domain.Exceptions
{
    public class CategoryDeleteException : CategorizerExceptionBase
    {
        public CategoryDeleteException(string message) : base(message)
        {
        }
    }
}