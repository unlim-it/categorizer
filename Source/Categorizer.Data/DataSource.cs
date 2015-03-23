namespace Categorizer.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Categorizer.Domain.Interfaces;
    using Categorizer.Domain.Models;

    public class DataSource : IDataSource
    {
        public async Task<IEnumerable<Category>> GetCategories(Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new DataContext())
            {
                IQueryable<Category> query = context.Categories;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                query = query.Include("Keywords");

                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<Fragment>> GetFragments(Expression<Func<Fragment, bool>> filter = null, int count = 0)
        {
            using (var context = new DataContext())
            {
                IQueryable<Fragment> query = context.Fragments;
                if (filter != null)
                {
                    query = query.Where(filter)
                        .OrderBy(it => it.CreatedAt);
                }

                if (count > 0)
                {
                    query = query.OrderBy(it => it.CreatedAt).Take(count);
                }

                query = query.Include("Category.Keywords");

                return await query.ToListAsync();
            }
        }

        public async Task<bool> IsCategoryInUse(Guid categoryId)
        {
            using (var context = new DataContext())
            {
                return await context.Fragments.AnyAsync(it => it.CategoryId == categoryId);
            }
        }

        public async Task<IEnumerable<Keyword>> GetKeywords()
        {
            using (var context = new DataContext())
            {
                return await context.Keywords.ToListAsync();
            }
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            using (var context = new DataContext())
            {
                var category = new Category { Id = categoryId };
                context.Categories.Attach(category);

                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategory(Category category)
        {
            using (var context = new DataContext())
            {
                var dbCategory = context.Categories
                    .Include("Keywords")
                    .Single(it => it.Id == category.Id);

                var currentKeywords = dbCategory.Keywords.ToList();

                foreach (var dbKeyword in currentKeywords)
                {
                    if (category.Keywords.All(it => it.Id != dbKeyword.Id))
                    {
                        dbCategory.Keywords.Remove(dbKeyword);
                    }
                }

                foreach (var keyword in category.Keywords)
                {
                    if (currentKeywords.All(it => it.Id != keyword.Id))
                    {
                        if (keyword.Id == Guid.Empty)
                        {
                            keyword.Id = Guid.NewGuid();
                        }

                        dbCategory.Keywords.Add(keyword);
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task InsertCategory(Category category)
        {
            using (var context = new DataContext())
            {
                category.Id = Guid.NewGuid();

                foreach (var keyword in category.Keywords)
                {
                    if (keyword.Id != Guid.Empty)
                    {
                        context.Keywords.Attach(keyword);
                    }
                    else
                    {
                        keyword.Id = Guid.NewGuid();
                    }
                }

                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task InsertFragment(Fragment fragment)
        {
            using (var context = new DataContext())
            {
                context.Fragments.Add(fragment);
                await context.SaveChangesAsync();
            }
        }
    }
}