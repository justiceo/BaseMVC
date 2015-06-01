using Blogg.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blogg.DAL
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext()
            : base("DefaultConnection", false)
        {
        }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } 

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }
    }
}