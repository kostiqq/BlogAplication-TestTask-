using Microsoft.EntityFrameworkCore;

namespace BlogAplication.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
