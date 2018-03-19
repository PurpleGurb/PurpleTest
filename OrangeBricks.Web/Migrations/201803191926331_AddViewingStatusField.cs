namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewingStatusField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewings", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewings", "Status");
        }
    }
}
