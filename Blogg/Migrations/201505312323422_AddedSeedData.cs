using System.Data.Entity.Migrations;

namespace Blogg.Migrations
{
    public partial class AddedSeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                {
                    ID = c.Int(false, true),
                    Content = c.String(),
                    CreatedDate = c.DateTime(false),
                    ModifiedDate = c.DateTime(false),
                    Status = c.String(),
                    parent = c.String(),
                    PostID = c.Int(false)
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, true)
                .Index(t => t.PostID);

            CreateTable(
                "dbo.CommentMetas",
                c => new
                {
                    ID = c.Int(false, true),
                    CommentID = c.Int(false),
                    Key = c.String(),
                    Value = c.String()
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.CommentID, true)
                .Index(t => t.CommentID);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    ID = c.Int(false, true),
                    Title = c.String(),
                    CreatedDate = c.DateTime(false),
                    ModifiedDate = c.DateTime(false),
                    Excerpt = c.String(),
                    Content = c.String(),
                    Status = c.String(),
                    PostType = c.String()
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.PostMetas",
                c => new
                {
                    ID = c.Int(false, true),
                    PostID = c.Int(false),
                    Key = c.String(),
                    Value = c.String()
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, true)
                .Index(t => t.PostID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.PostMetas", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.CommentMetas", "CommentID", "dbo.Comments");
            DropIndex("dbo.PostMetas", new[] {"PostID"});
            DropIndex("dbo.CommentMetas", new[] {"CommentID"});
            DropIndex("dbo.Comments", new[] {"PostID"});
            DropTable("dbo.PostMetas");
            DropTable("dbo.Posts");
            DropTable("dbo.CommentMetas");
            DropTable("dbo.Comments");
        }
    }
}