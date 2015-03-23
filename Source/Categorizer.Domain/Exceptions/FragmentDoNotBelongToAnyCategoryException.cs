namespace Categorizer.Domain.Exceptions
{
    public class FragmentDoNotBelongToAnyCategoryException : CategorizerExceptionBase
    {
        public FragmentDoNotBelongToAnyCategoryException() 
            : base(Resources.ExceptionTextFragmentDoNotBelongToAnyCategory)
        {
        }
    }
}