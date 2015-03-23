namespace Categorizer.Domain.Exceptions
{
    public class CategoryKeywordsEmptyException : CategorizerExceptionBase
    {
        public CategoryKeywordsEmptyException() : base(Resources.ExceptionCategoryKeywordsEmpty)
        {

        }
    }
}