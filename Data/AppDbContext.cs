using Microsoft.EntityFrameworkCore;
using ticketSystem.Models;

namespace ticketSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Bug> bugs { get; set; }
        public DbSet<Feature> features { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.userId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Bug>()
                .Property(b => b.bugId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Feature>()
                .Property(f => f.featureId).ValueGeneratedOnAdd();
        }

    }
}
