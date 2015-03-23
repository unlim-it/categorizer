namespace Categorizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fragments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"),
                        Text = c.String(),
                        Category_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.KeywordCategories",
                c => new
                    {
                        Keyword_Id = c.Guid(nullable: false),
                        Category_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keyword_Id, t.Category_Id })
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fragments", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.KeywordCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.KeywordCategories", "Keyword_Id", "dbo.Keywords");
            DropIndex("dbo.KeywordCategories", new[] { "Category_Id" });
            DropIndex("dbo.KeywordCategories", new[] { "Keyword_Id" });
            DropIndex("dbo.Fragments", new[] { "Category_Id" });
            DropTable("dbo.KeywordCategories");
            DropTable("dbo.Fragments");
            DropTable("dbo.Keywords");
            DropTable("dbo.Categories");
        }
    }
}
