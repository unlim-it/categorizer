namespace Categorizer.Domain.Logic
{
    using Categorizer.Domain.Exceptions;

    public class Validator
    {
        public static void Required(string fieldName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException(string.Format(Resources.ExceptionValidationRequiredField, fieldName));
            }
        }
    }
}