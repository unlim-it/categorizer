namespace Categorizer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Categorizer.Domain.Exceptions;
    using Categorizer.Domain.Interfaces;
    using Categorizer.Domain.Logic;
    using Categorizer.Domain.Models;

    public class AutoCategorizer
    {
        private readonly IDataSource dataSource;
        private readonly ITextAnalizer textAnalizer;

        public AutoCategorizer(IDataSource dataSource, ITextAnalizer textAnalizer)
        {
            this.dataSource = dataSource;
            this.textAnalizer = textAnalizer;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await this.dataSource.GetCategories();
        }
        
        public async Task<Category> GetCategory(Guid categoryId)
        {
            var categories = await this.dataSource.GetCategories(c => c.Id == categoryId);
            var foundCategories = categories.ToList();

            if (!foundCategories.Any())
            {
                throw new CategoryNotFoundException();
            }

            return foundCategories.Single();
        }

        public async Task AddCategory(Category category)
        {
            Validator.Required(Resources.FieldCategoryName, category.Name);
            
            category.Id = Guid.Empty;

            await this.ProcessKeywords(category);
            await this.dataSource.InsertCategory(category); 
        }

        public async Task UpdateCategory(Category category)
        {
            Validator.Required(Resources.FieldCategoryName, category.Name);

            await this.ProcessKeywords(category);
            await this.dataSource.UpdateCategory(category); 
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var isInUse = await this.dataSource.IsCategoryInUse(categoryId);
            if (isInUse)
            {
                throw new CategoryDeleteException(Resources.ExceptionCategoryInUse);
            }

            await this.dataSource.DeleteCategory(categoryId); 
        }

        public async Task<Fragment> AddText(string fragmentText)
        {
            Validator.Required(Resources.FieldFragmentText, fragmentText);

            var categories = await this.GetCategories();

            foreach (var category in categories)
            {
                var categoryKeywords = category.Keywords.Select(it => it.Value).ToArray();
                var matchKeywords = this.textAnalizer.SearchKeywords(fragmentText, categoryKeywords);

                if (!matchKeywords.Any())
                {
                    continue;
                }

                var fragment = new Fragment
                {
                    Id = Guid.NewGuid(), 
                    CategoryId = category.Id, 
                    Text = fragmentText,
                    CreatedAt = DateTime.Now
                };

                await this.dataSource.InsertFragment(fragment);
                
                fragment.Category = category;
                return fragment;
            }

            throw new FragmentDoNotBelongToAnyCategoryException();
        }

        public async Task<IEnumerable<Fragment>> GetFragments()
        {
            return await this.dataSource.GetFragments();
        }

        public async Task<IEnumerable<Fragment>> GetLatestFragments(int count = 10)
        {
            return await this.dataSource.GetFragments(count:count);
        }

        private async Task ProcessKeywords(Category category)
        {
            if (category.Keywords == null || !category.Keywords.Any())
            {
                throw new CategoryKeywordsEmptyException();
            }

            var keywords = await this.dataSource.GetKeywords();
            foreach (var categoryKeyword in category.Keywords)
            {
                Validator.Required(Resources.FieldKeywordValue, categoryKeyword.Value);

                var existKeyword =
                    keywords.SingleOrDefault(
                        it => it.Value.Equals(categoryKeyword.Value, StringComparison.InvariantCultureIgnoreCase));

                categoryKeyword.Id = existKeyword != null ? existKeyword.Id : Guid.Empty;
            }
        }
    }
}