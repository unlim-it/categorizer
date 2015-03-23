namespace Categorizer.Domain.Interfaces
{
    public interface ITextAnalizer
    {
        string[] SearchKeywords(string text, string[] keywords);
    }
}