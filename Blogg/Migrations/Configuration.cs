using System.Collections.Generic;
using Blogg.Models;

namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blogg.Models.BloggDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blogg.Models.BloggDbContext context)
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

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "A post Title",
                    ModifiedDate = DateTime.Now,
                    PostType = "post"
                },
                new Post
                {
                    Title = "Another post Title",
                    ModifiedDate = DateTime.Now,
                    PostType = "post"
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
                    Post = posts.FirstOrDefault()
                },
                new Comment
                {
                    Content = "another comment body",
                    ModifiedDate = DateTime.Now,
                    Post = posts.LastOrDefault()
                }
            };
            commnets.ForEach(c => context.Comments.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}
