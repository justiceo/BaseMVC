using System.Data.Entity;
using Blogg.Models;
using Blogg.Models.Blog;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blogg.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}