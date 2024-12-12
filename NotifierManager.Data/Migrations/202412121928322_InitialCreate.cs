namespace NotifierManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ColorHex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        NotificationTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DisplaySettingsJson = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Notifications", new[] { "CategoryId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Categories");
        }
    }
}
