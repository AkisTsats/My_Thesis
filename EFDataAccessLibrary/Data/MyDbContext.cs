using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() 
        { 
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        { }

        public const string connectionString = "Server=localhost;User Id=root;Password='r00t;';Database=announcementapi";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.User)
                .WithMany(b => b.Announcements);

            modelBuilder.Entity<Announcement>()
                .HasAlternateKey(c => c.Title);
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
       //public DbSet<Preference> Preferences { get; set; }
       // public DbSet<Permissions> Permissions { get; set; }
       // public DbSet<Revision> Revisions { get; set; }
       // public DbSet<Subjects> Subjects { get; set; }
       // public DbSet<Year> Years { get; set; }
    }
}
