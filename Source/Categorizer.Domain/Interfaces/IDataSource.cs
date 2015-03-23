namespace Categorizer.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Categorizer.Domain.Models;

    public interface IDataSource
    {
        Task<IEnumerable<Category>> GetCategories(Expression<Func<Category, bool>> filter = null);
        Task<IEnumerable<Fragment>> GetFragments(Expression<Func<Fragment, bool>> filter = null, int count = 0);
        Task<IEnumerable<Keyword>> GetKeywords();
        Task DeleteCategory(Guid categoryId);
        Task UpdateCategory(Category category);
        Task InsertCategory(Category category);
        Task InsertFragment(Fragment fragment);
        Task<bool> IsCategoryInUse(Guid categoryId);
    }
}