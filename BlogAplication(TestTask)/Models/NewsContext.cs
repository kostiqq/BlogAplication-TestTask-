using Microsoft.EntityFrameworkCore;

namespace BlogAplication.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<News> news { get; set; }

    }
}
