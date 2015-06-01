using System.Collections.Generic;
using Blogg.DAL;
using Blogg.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BloggDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BloggDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var users = new List<ApplicationUser>
            //{
            //    new ApplicationUser
            //    {
            //        Email = "test@yahoo.com",
            //        AccessFailedCount = 0,
            //        EmailConfirmed = true,
            //        UserName = "demo"
                    
            //    },
            //    new ApplicationUser
            //    {
            //        Email = "test2@yahoo.com",
            //        AccessFailedCount = 0,
            //        EmailConfirmed = true,
            //        UserName = "tester",
            //        Roles = { 
            //            new IdentityUserRole
            //            {
            //                RoleId = "3"
            //            }
            //        },
            //        Logins =
            //        {
            //            new IdentityUserLogin()
            //        }
            //    },
            //    new ApplicationUser
            //    {
            //        Email = "test3@yahoo.com",
            //        AccessFailedCount = 0,
            //        EmailConfirmed = true,
            //        UserName = "just",
            //        Roles = { 
            //            new IdentityUserRole
            //            {
            //                RoleId = "3"
            //            }
            //        },
            //        Logins =
            //        {
            //            new IdentityUserLogin()
            //        }
            //    }
            //};
            //users.ForEach(u => context.UserDbContext.Users.AddOrUpdate(u));
            //context.UserDbContext.SaveChanges();
            //context.SaveChanges();
            //AddUserAndRole(context.UserDbContext);

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "A post Title",
                    ModifiedDate = DateTime.Now,
                    PostType = "post",
                    //ApplicationUser = context.UserDbContext.Users.FirstOrDefault()
                },
                new Post
                {
                    Title = "Another post Title",
                    ModifiedDate = DateTime.Now,
                    PostType = "post",
                    //ApplicationUser = context.UserDbContext.Users.FirstOrDefault()
                }
            };
            posts.ForEach(p => context.Posts.AddOrUpdate(p));
            context.SaveChanges();

            var commnets = new List<Comment>
            {
                new Comment
                {
                    Content = "comment body",
                    ModifiedDate = DateTime.Now,
                    Post = posts.FirstOrDefault(),
                    //ApplicationUser = context.UserDbContext.Users.FirstOrDefault()
                },
                new Comment
                {
                    Content = "another comment body",
                    ModifiedDate = DateTime.Now,
                    Post = posts.LastOrDefault(),
                    //ApplicationUser = context.UserDbContext.Users.FirstOrDefault()
                }
            };
            commnets.ForEach(c => context.Comments.AddOrUpdate(c));
            context.SaveChanges();
        }

        bool AddUserAndRole(UserDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }
    }
}
