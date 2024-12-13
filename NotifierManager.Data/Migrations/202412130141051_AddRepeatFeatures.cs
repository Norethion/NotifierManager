namespace NotifierManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRepeatFeatures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "LastRepeatDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "LastRepeatDate");
        }
    }
}
