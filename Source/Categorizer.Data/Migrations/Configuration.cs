namespace Categorizer.Data.Migrations
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;

    using Categorizer.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            context.Categories.AddOrUpdate(c => c.Name, 
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Programming Languages",
                    Keywords = new Collection<Keyword>
                    {
                        new Keyword { Id = Guid.NewGuid(), Value = "C++"},
                        new Keyword { Id = Guid.NewGuid(), Value = "C#"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Visual Basic"},
                        new Keyword { Id = Guid.NewGuid(), Value = "PHP"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Objective C"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Pascal"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Cobol"},
                        new Keyword { Id = Guid.NewGuid(), Value = "JavaScript"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Ruby"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Delphi"},
                        new Keyword { Id = Guid.NewGuid(), Value = "SQL"}
                    }
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = ".NET Basic Technologies",
                    Keywords = new Collection<Keyword>
                    {
                        new Keyword { Id = Guid.NewGuid(), Value = ".NET Framework"},
                        new Keyword { Id = Guid.NewGuid(), Value = "WinForms"},
                        new Keyword { Id = Guid.NewGuid(), Value = "WPF"},
                        new Keyword { Id = Guid.NewGuid(), Value = "Silverlight"},
                        new Keyword { Id = Guid.NewGuid(), Value = "ASP.NET"},
                        new Keyword { Id = Guid.NewGuid(), Value = "ASP.NET MVC"},
                        new Keyword { Id = Guid.NewGuid(), Value = "ADO.NET"},
                        new Keyword { Id = Guid.NewGuid(), Value = "ASP.NET AJAX"}
                    }
                },
                new Category
                {
                    Id = Guid.NewGuid(), 
                    Name = "Holidays",
                    Keywords = new Collection<Keyword>
                    {
                        new Keyword { Id = Guid.NewGuid(), Value = "christmas"},
                        new Keyword { Id = Guid.NewGuid(), Value = "thanksgiving"},
                        new Keyword { Id = Guid.NewGuid(), Value = "halloween"},
                        new Keyword { Id = Guid.NewGuid(), Value = "new year"}
                    }
                },
                new Category
                {
                    Id = Guid.NewGuid(), 
                    Name = "Sports",
                    Keywords = new Collection<Keyword>
                    {
                        new Keyword { Id = Guid.NewGuid(), Value = "sport" },
                        new Keyword { Id = Guid.NewGuid(), Value = "hockey" },
                        new Keyword { Id = Guid.NewGuid(), Value = "soccer" },
                        new Keyword { Id = Guid.NewGuid(), Value = "baseball" },
                        new Keyword { Id = Guid.NewGuid(), Value = "basketball" },
                        new Keyword { Id = Guid.NewGuid(), Value = "football" },
                        new Keyword { Id = Guid.NewGuid(), Value = "olympics" },
                        new Keyword { Id = Guid.NewGuid(), Value = "climbing" },
                        new Keyword { Id = Guid.NewGuid(), Value = "lacrosse" },
                        new Keyword { Id = Guid.NewGuid(), Value = "nascar" },
                        new Keyword { Id = Guid.NewGuid(), Value = "surfing" },
                        new Keyword { Id = Guid.NewGuid(), Value = "boxing" },
                        new Keyword { Id = Guid.NewGuid(), Value = "golf" }
                    }
                });
        }
    }
}
