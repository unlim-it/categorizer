namespace Categorizer.Data
{
    using System.Data.Entity;
    using Categorizer.Data.Migrations;

    public class Database
    {
        public static void Initialize()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

            using (var temp = new DataContext())
            {
                temp.Database.Initialize(true);
            }
        }
    }
}