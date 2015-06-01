using System.Data.Entity.Migrations;

namespace Blogg.Migrations
{
    public partial class addedBloggUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ApplicationUserID", c => c.Int(false));
            AddColumn("dbo.Posts", "ApplicationUserID", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Posts", "ApplicationUserID");
            DropColumn("dbo.Comments", "ApplicationUserID");
        }
    }
}