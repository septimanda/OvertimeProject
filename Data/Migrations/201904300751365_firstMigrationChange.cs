namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigrationChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Overtimes", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Overtimes", new[] { "Categories_Id" });
            DropColumn("dbo.Overtimes", "Categories_Id");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Overtimes", "Categories_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Overtimes", "Categories_Id");
            AddForeignKey("dbo.Overtimes", "Categories_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
