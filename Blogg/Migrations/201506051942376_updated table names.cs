namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtablenames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogins");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            AddColumn("dbo.Comments", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "ApplicationUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "parent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "parent", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "ApplicationUserID");
            DropColumn("dbo.Comments", "ApplicationUserID");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
            RenameTable(name: "dbo.UserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.UserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}
