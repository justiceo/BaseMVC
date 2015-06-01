namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBloggUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "ApplicationUserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ApplicationUserID");
            DropColumn("dbo.Comments", "ApplicationUserID");
        }
    }
}
