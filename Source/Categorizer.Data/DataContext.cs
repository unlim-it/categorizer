namespace Categorizer.Data
{
    using System.Data.Entity;
    using Categorizer.Domain.Models;

    internal class DataContext : DbContext
    {
        public DataContext()
            : base("name=CategorizerData")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Fragment> Fragments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}