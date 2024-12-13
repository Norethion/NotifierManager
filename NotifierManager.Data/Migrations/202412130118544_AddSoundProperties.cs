namespace NotifierManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoundProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "EnableSound", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "EnableSound");
        }
    }
}
