namespace Categorizer.Domain.Exceptions
{
    public class CategoryNotFoundException : CategorizerExceptionBase
    {
        public CategoryNotFoundException() : base(Resources.ExceptionCategoryNotFound)
        {
        }
    }
}