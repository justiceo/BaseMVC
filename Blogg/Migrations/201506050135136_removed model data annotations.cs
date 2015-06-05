namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmodeldataannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
        }
    }
}
