namespace Categorizer.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtColumnToFragmentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fragments", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Fragments", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Fragments", name: "Category_Id", newName: "CategoryId");
            AddColumn("dbo.Fragments", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Fragments", "CategoryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Fragments", "CategoryId");
            AddForeignKey("dbo.Fragments", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fragments", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Fragments", new[] { "CategoryId" });
            AlterColumn("dbo.Fragments", "CategoryId", c => c.Guid());
            DropColumn("dbo.Fragments", "CreatedAt");
            RenameColumn(table: "dbo.Fragments", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Fragments", "Category_Id");
            AddForeignKey("dbo.Fragments", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
