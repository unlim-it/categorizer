namespace Categorizer.Services.Tools
{
    using System.Linq;

    using Categorizer.Domain.Models;
    using Categorizer.Services.Contracts;

    public class CategorizerConverter
    {
        public static DtoCategory ToDto(Category category)
        {
            var dto = new DtoCategory
            {
                Id = category.Id,
                Name = category.Name,
                Keywords = category.Keywords != null ? category.Keywords.Select(ToDto).ToList() : null
            };

            return dto;
        }

        public static DtoKeyword ToDto(Keyword keyword)
        {
            var dto = new DtoKeyword
            {
                Id = keyword.Id,
                Value = keyword.Value
            };

            return dto;
        }

        public static DtoFragment ToDto(Fragment fragment)
        {
            var dto = new DtoFragment
            {
                Id = fragment.Id,
                Text = fragment.Text,
                CategoryId = fragment.CategoryId,
                CreateAt = fragment.CreatedAt,
                Category = fragment.Category != null ? ToDto(fragment.Category) : null
            };

            return dto;
        }

        public static Category ToDomain(DtoCategory dtoCategory)
        {
            var category = new Category
            {
                Id = dtoCategory.Id,
                Name = dtoCategory.Name,
                Keywords = dtoCategory.Keywords != null 
                    ? dtoCategory.Keywords.Select(ToDomain).ToList() : null
            };

            return category;
        }

        public static Keyword ToDomain(DtoKeyword dtoKeyword)
        {
            var keyword = new Keyword
            {
                Id = dtoKeyword.Id,
                Value = dtoKeyword.Value
            };

            return keyword;
        }

        public static Fragment ToDomain(DtoFragment dtoFragment)
        {
            var domain = new Fragment
            {
                Id = dtoFragment.Id,
                Text = dtoFragment.Text,
                CategoryId = dtoFragment.CategoryId,
                CreatedAt = dtoFragment.CreateAt,
                Category = dtoFragment.Category != null ? ToDomain(dtoFragment.Category) : null
            };

            return domain;
        }
    }
}