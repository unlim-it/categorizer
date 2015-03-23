namespace Categorizer.Domain.Tests
{
    using Categorizer.Domain.Logic;

    using FluentAssertions;

    using NUnit.Framework;

    public class RegexTextAnalizerTests
    {
        [Test]
        public void Should_ReturnEmptyCollection_When_SearchForNotExistingKeywords()
        {
            var textAnalizer = new RegexTextAnalizer();

            const string searchText = "Visual Studio and .NET have been two bedrocks of the Microsoft"  +
            "developer ecosystem for over a decade.  With over 1.8 billion installations of .NET and "  +
            "over 7 million downloads of Visual Studio 2013 in just the last year, Visual Studio and "  +
            ".NET are enabling millions of developers to build some of today’s most important software" +
            "and services powering businesses, apps and sites.";

            var keywords = new[] { "c#", "javascript" };

            var result = textAnalizer.SearchKeywords(searchText, keywords);

            result.Should().BeEmpty();
        }

        [Test]
        public void Should_ReturnFoundKeywords_When_SearchForExistingKeywords()
        {
            var textAnalizer = new RegexTextAnalizer();

            const string searchText = "Visual Studio and .NET have been two bedrocks of the Microsoft" +
            "developer ecosystem for over a decade.  With over 1.8 billion installations of .NET and " +
            "over 7 million downloads of Visual Studio 2013 in just the last year, Visual Studio and " +
            ".NET are enabling millions of developers to build some of today’s most important software" +
            "and services powering businesses, apps and sites.";

            var keywords = new[] { "Visual Studio", "javascript" };

            var result = textAnalizer.SearchKeywords(searchText, keywords);

            result.Should().HaveCount(1);
            result.Should().OnlyContain(w => w == "Visual Studio");
        }

        [Test]
        public void Should_IgnoreCase_When_SearchForExistingKeywords()
        {
            var textAnalizer = new RegexTextAnalizer();

            const string searchText = "Visual Studio and .NET have been two bedrocks of the Microsoft" +
            "developer ecosystem for over a decade.  With over 1.8 billion installations of .NET and " +
            "over 7 million downloads of Visual Studio 2013 in just the last year, Visual Studio and " +
            ".NET are enabling millions of developers to build some of today’s most important software" +
            "and services powering businesses, apps and sites.";

            var keywords = new[] { "vISUAL sTUDIO", ".net" };

            var result = textAnalizer.SearchKeywords(searchText, keywords);

            result.Should().HaveCount(2);
            result.Should().Contain(w => w == "vISUAL sTUDIO");
            result.Should().Contain(w => w == ".net");
        }
    }
}
