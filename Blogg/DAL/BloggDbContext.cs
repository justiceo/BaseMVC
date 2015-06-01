using System.Data.Entity;
using Blogg.Models;

namespace Blogg.DAL
{
    public class BloggDbContext : DbContext
    {
        public BloggDbContext()
            : base("DefaultConnection")
        {
        }

        public static BloggDbContext Creat()
        {
            return  new BloggDbContext();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } 

        public UserDbContext UserDbContext { get; set; }

    }
}