using System.Collections.Generic;
using Blogg.Models.Blog;

namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blogg.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blogg.DAL.ApplicationDbContext context)
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

            // Seed Application Users

            // Seed Blog Content
            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Post One Here",
                    Content = "Sample post content",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
					ApplicationUser = context.Users.FirstOrDefault()
                },
                new Post
                {
                    Title = "Post Two",
                    Content = "Amd Sample post content",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
					ApplicationUser = context.Users.LastOrDefault()
                }
            };
            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment
                {
                    Content = "some comment",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Post = posts.FirstOrDefault()
                },
                new Comment
                {
                    Content = "another comment again",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Post = posts.LastOrDefault()
                }
            };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
			
        }
    }
}
