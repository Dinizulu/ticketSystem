using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ticketSystem.Models;

namespace ticketSystem.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
            base.OnModelCreating(modelBuilder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{Name = "User",NormalizedName = "USER"},
                new IdentityRole{Name = "ADM",NormalizedName = "ADMINISTRATOR"},
                new IdentityRole{Name = "RD",NormalizedName = "RESEARCH AND DEVELOPMENT"},
                new IdentityRole{Name = "QA",NormalizedName = "Quality Assurance"},
                new IdentityRole{Name = "PM",NormalizedName = "PROJECT MANAGER"}
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
