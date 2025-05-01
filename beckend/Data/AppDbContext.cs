namespace beckend.Data
{
    using Microsoft.EntityFrameworkCore;
    using beckend.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BugItem> Bugs { get; set; }
    }
}