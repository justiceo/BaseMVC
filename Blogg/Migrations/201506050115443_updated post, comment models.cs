namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedpostcommentmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Parent", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "ApplicationUserID");
            DropColumn("dbo.Posts", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "ApplicationUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Comments", "Parent", c => c.String());
            AlterColumn("dbo.Comments", "Content", c => c.String());
        }
    }
}
