namespace Categorizer.Domain.Logic
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Categorizer.Domain.Interfaces;

    public class RegexTextAnalizer : ITextAnalizer
    {
        public string[] SearchKeywords(string text, string[] keywords)
        {
            var regex = new Regex(string.Join("|", keywords.Select(Regex.Escape)), RegexOptions.IgnoreCase);
            if (regex.IsMatch(text))
            {
                var matches = regex.Matches(text)
                    .Cast<Match>()
                    .Where(m => m.Success)
                    .Select(m => keywords.Single(k => k.Equals(m.Value, StringComparison.InvariantCultureIgnoreCase)))
                    .Distinct()
                    .ToArray();

                return matches;
            }

            return new string[] { };
        }
    }
}