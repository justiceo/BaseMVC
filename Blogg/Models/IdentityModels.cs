using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blogg.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } 

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }
    }

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

        public UserDbContext UserDbContext { get; set; }

    }
}