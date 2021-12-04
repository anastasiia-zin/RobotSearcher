using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure
{
    public class DbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Robot> Robots { get; set; }
        public DbSet<CategoryRobot> CategoryRobots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<RobotIssue> RobotIssues { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AppUserNotification> AppUserNotifications { get; set; }

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BaseEntity>().Property(x => x.Id)
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd()
                .IsRequired();
             modelBuilder.Entity<BaseEntity>().HasKey(x => x.Id);
             
             /*modelBuilder.Entity<Category>()
                 .HasMany(x=> x.Robots)
                 .WithMany(x => x.Categories);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}