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

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "admin".ToUpper(),
                ConcurrencyStamp = "1",
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2",
                Name = "user",
                ConcurrencyStamp = "2",
                NormalizedName = "user".ToUpper()
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "3",
                Name = "director",
                ConcurrencyStamp = "3",
                NormalizedName = "director".ToUpper()
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}