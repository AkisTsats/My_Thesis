﻿using Microsoft.EntityFrameworkCore;
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
                .HasOne(a => a.Image)
                .WithOne(b => b.Announcement)
                .HasForeignKey<Image>(c => c.ImageID);

            // modelBuilder.Entity<Announcement>()
            //   .HasAlternateKey(c => c.Title);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Preferences)
                .WithOne(b => b.User);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Permissions)
                .WithOne(b => b.User);

            modelBuilder.Entity<Statistics>()
                .HasNoKey();

            modelBuilder.Entity<YearsList>()
                .HasMany(a => a.Users)
                .WithMany(b => b.YearsList);

            modelBuilder.Entity<SubjectsList>()
                .HasMany(a => a.Users)
                .WithMany(b => b.SubjectsList);


            modelBuilder.Entity<CategoriesList>()
                .HasMany(a => a.Users)
                .WithMany(b => b.CategoriesList);


            modelBuilder.Entity<CategoriesListUser>()
                .HasKey(a => new { a.UserID, a.CategoryID});

            modelBuilder.Entity<CategoriesList>()
                .HasMany(a => a.Announcements)
                .WithMany(b => b.CategoriesList);


            modelBuilder.Entity<CategoriesListAnnouncement>()
                .HasKey(a => new { a.AnnouncementID, a.CategoryID});
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Statistics> Stats { get; set; }
        public DbSet<YearsList> YList { get; set; }
        public DbSet<CategoriesList> CList { get; set; }
        public DbSet<SubjectsList> SList { get; set; }
        public DbSet<CategoriesListAnnouncement> categoriesListannouncement { get; set; }
        public DbSet<CategoriesListUser> categorieslistuser { get; set; }

    }
}