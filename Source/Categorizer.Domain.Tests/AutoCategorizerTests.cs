namespace Categorizer.Domain.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Categorizer.Domain.Exceptions;
    using Categorizer.Domain.Interfaces;
    using Categorizer.Domain.Models;

    using FluentAssertions;

    using NSubstitute;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    public class AutoCategorizerTests
    {
        [Test, ExpectedException(typeof(FragmentDoNotBelongToAnyCategoryException))]
        public async void Should_ThrowException_When_AnyCategoryIsNotMatch()
        {
            var textAnalizer = Substitute.For<ITextAnalizer>();
            textAnalizer.SearchKeywords(Arg.Any<string>(), Arg.Any<string[]>()).Returns(new string[]{});

            var dataSource = Substitute.For<IDataSource>();
            dataSource.GetCategories().Returns(Task.FromResult<IEnumerable<Category>>(new List<Category>()));

            var fixture = new Fixture();

            var categorizer = new AutoCategorizer(dataSource, textAnalizer);
            await categorizer.AddText(fixture.Create<string>());
        }

        [Test]
        public async void Should_ReturnFragment_When_AddedTextSuccessfully()
        {
            var fixture = new Fixture();

            var category = fixture.Build<Category>().Without(it => it.Keywords).Create();
            category.Keywords = new Collection<Keyword> { fixture.Build<Keyword>().Without(it => it.Categories).Create() };

            var textAnalizer = Substitute.For<ITextAnalizer>();
            textAnalizer.SearchKeywords(Arg.Any<string>(), Arg.Any<string[]>()).Returns(new[] { category.Keywords.First().Value });

            var dataSource = Substitute.For<IDataSource>();
            dataSource.GetCategories().Returns(Task.FromResult<IEnumerable<Category>>(new List<Category> { category }));
            
            var categorizer = new AutoCategorizer(dataSource, textAnalizer);
            var fragment = await categorizer.AddText(fixture.Create<string>());

            fragment.Category.Id.Should().Be(category.Id);
        }
    }
}