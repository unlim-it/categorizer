namespace Categorizer.Services.Tests
{
    using System.Linq;

    using Categorizer.Domain.Models;
    using Categorizer.Services.Contracts;
    using Categorizer.Services.Tools;

    using FluentAssertions;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    public class CategorizerConverterTests
    {
        [Test]
        public void Should_PropertiesValuesMatch_When_ConvertedCategoryToDtoObject()
        {
            var fixture = new Fixture();
            var category = fixture.Build<Category>().Without(it => it.Keywords).Create();
            category.Keywords = new[] { fixture.Build<Keyword>().Without(it => it.Categories).Create() };

            var dtoCategory = CategorizerConverter.ToDto(category);

            dtoCategory.Id.Should().Be(category.Id);
            dtoCategory.Name.Should().Be(category.Name);
            dtoCategory.Keywords.Count().Should().Be(category.Keywords.Count);
        }

        [Test]
        public void Should_PropertiesValuesMatch_When_ConvertedFragmentToDtoObject()
        {
            var fixture = new Fixture();
            var fragment = fixture.Build<Fragment>().Without(it => it.Category).Create();
            fragment.Category = fixture.Build<Category>().Without(it => it.Keywords).Create();
            fragment.Category.Keywords = new[] { fixture.Build<Keyword>().Without(it => it.Categories).Create() };

            var dtoFragment = CategorizerConverter.ToDto(fragment);

            dtoFragment.Id.Should().Be(fragment.Id);
            dtoFragment.Text.Should().Be(fragment.Text);
            dtoFragment.CategoryId.Should().Be(fragment.CategoryId);
            dtoFragment.CreateAt.Should().Be(fragment.CreatedAt);
            dtoFragment.Category.Id.Should().Be(fragment.Category.Id);
        }

        [Test]
        public void Should_PropertiesValuesMatch_When_ConvertedKeywordToDtoObject()
        {
            var fixture = new Fixture();
            var category = fixture.Build<Keyword>().Without(it => it.Categories).Create();

            var dtoKeyword = CategorizerConverter.ToDto(category);

            dtoKeyword.Id.Should().Be(category.Id);
            dtoKeyword.Value.Should().Be(category.Value);
        }


        [Test]
        public void Should_PropertiesValuesMatch_When_ConvertedDtoCategoryToDomainObject()
        {
            var fixture = new Fixture();
            var category = fixture.Create<DtoCategory>();

            var dtoCategory = CategorizerConverter.ToDomain(category);

            dtoCategory.Id.Should().Be(category.Id);
            dtoCategory.Name.Should().Be(category.Name);
            dtoCategory.Keywords.Count().Should().Be(category.Keywords.Count());
        }

        [Test]
        public void Should_PropertiesValuesMatch_When_ConvertedDtoKeywordToDomainObject()
        {
            var fixture = new Fixture();
            var dtoKeyword = fixture.Create<DtoKeyword>();

            var keyword = CategorizerConverter.ToDomain(dtoKeyword);

            keyword.Id.Should().Be(dtoKeyword.Id);
            keyword.Value.Should().Be(dtoKeyword.Value);
        }

        [Test]
        public void Should_PropertiesValuesMatch_When_ConvertedDtoFragmentToDomainObject()
        {
            var fixture = new Fixture();
            var dtoFragment = fixture.Create<DtoFragment>();

            var fragment = CategorizerConverter.ToDomain(dtoFragment);

            fragment.Id.Should().Be(dtoFragment.Id);
            fragment.Text.Should().Be(dtoFragment.Text);
            fragment.CreatedAt.Should().Be(dtoFragment.CreateAt);
            fragment.CategoryId.Should().Be(dtoFragment.CategoryId);
            fragment.Category.Id.Should().Be(dtoFragment.Category.Id);
        }
    }
}
