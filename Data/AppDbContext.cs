using Microsoft.EntityFrameworkCore;
using ticketSystem.Models;

namespace ticketSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Bug> bugs { get; set; }
        public DbSet<Feature> features { get; set; }

    }
}
