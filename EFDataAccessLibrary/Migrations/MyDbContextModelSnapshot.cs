﻿// <auto-generated />
using System;
using EFDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AcademicYearsAnnouncement", b =>
                {
                    b.Property<int>("RelatesToAcademicYearsId")
                        .HasColumnType("int");

                    b.Property<int>("RelatesToAnnouncementsId")
                        .HasColumnType("int");

                    b.HasKey("RelatesToAcademicYearsId", "RelatesToAnnouncementsId");

                    b.HasIndex("RelatesToAnnouncementsId");

                    b.ToTable("AcademicYearsAnnouncement");
                });

            modelBuilder.Entity("AcademicYearsUser", b =>
                {
                    b.Property<int>("SelectedAcademicYearsId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedByUsersId")
                        .HasColumnType("int");

                    b.HasKey("SelectedAcademicYearsId", "SelectedByUsersId");

                    b.HasIndex("SelectedByUsersId");

                    b.ToTable("AcademicYearsUser");
                });

            modelBuilder.Entity("AnnouncementCategory", b =>
                {
                    b.Property<int>("RelatedToCategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("RelatesToAnnouncementsId")
                        .HasColumnType("int");

                    b.HasKey("RelatedToCategoriesId", "RelatesToAnnouncementsId");

                    b.HasIndex("RelatesToAnnouncementsId");

                    b.ToTable("AnnouncementCategory");
                });

            modelBuilder.Entity("AnnouncementSubject", b =>
                {
                    b.Property<int>("RelatedToSubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("RelatesToAnnouncementsId")
                        .HasColumnType("int");

                    b.HasKey("RelatedToSubjectsId", "RelatesToAnnouncementsId");

                    b.HasIndex("RelatesToAnnouncementsId");

                    b.ToTable("AnnouncementSubject");
                });

            modelBuilder.Entity("CategoryUser", b =>
                {
                    b.Property<int>("SelectedByUsersId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedCategoriesId")
                        .HasColumnType("int");

                    b.HasKey("SelectedByUsersId", "SelectedCategoriesId");

                    b.HasIndex("SelectedCategoriesId");

                    b.ToTable("CategoryUser");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.AcademicYears", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .HasColumnType("longtext");

                    b.Property<string>("Body")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<DateTime>("CreatedTs"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PrimaryResourceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PrimaryResourceId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<DateTime>("CreatedTs"));

                    b.Property<string>("FilePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("RelatesToAnnouncementId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelatesToAnnouncementId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<DateTime>("CreatedTs"));

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int?>("EnrollmentYear")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("NotificationSettings")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("PauseNotificationsUntil")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubjectUser", b =>
                {
                    b.Property<int>("SelectedByUsersId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedSubjectsId")
                        .HasColumnType("int");

                    b.HasKey("SelectedByUsersId", "SelectedSubjectsId");

                    b.HasIndex("SelectedSubjectsId");

                    b.ToTable("SubjectUser");
                });

            modelBuilder.Entity("AcademicYearsAnnouncement", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.AcademicYears", null)
                        .WithMany()
                        .HasForeignKey("RelatesToAcademicYearsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Data.Announcement", null)
                        .WithMany()
                        .HasForeignKey("RelatesToAnnouncementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcademicYearsUser", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.AcademicYears", null)
                        .WithMany()
                        .HasForeignKey("SelectedAcademicYearsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Data.User", null)
                        .WithMany()
                        .HasForeignKey("SelectedByUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnnouncementCategory", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.Category", null)
                        .WithMany()
                        .HasForeignKey("RelatedToCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Data.Announcement", null)
                        .WithMany()
                        .HasForeignKey("RelatesToAnnouncementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnnouncementSubject", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.Subject", null)
                        .WithMany()
                        .HasForeignKey("RelatedToSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Data.Announcement", null)
                        .WithMany()
                        .HasForeignKey("RelatesToAnnouncementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryUser", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.User", null)
                        .WithMany()
                        .HasForeignKey("SelectedByUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Data.Category", null)
                        .WithMany()
                        .HasForeignKey("SelectedCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Announcement", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("EFDataAccessLibrary.Data.Resource", "PrimaryResource")
                        .WithMany()
                        .HasForeignKey("PrimaryResourceId");

                    b.Navigation("Creator");

                    b.Navigation("PrimaryResource");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Resource", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.Announcement", "RelatesToAnnouncement")
                        .WithMany("RelatedResources")
                        .HasForeignKey("RelatesToAnnouncementId");

                    b.Navigation("RelatesToAnnouncement");
                });

            modelBuilder.Entity("SubjectUser", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Data.User", null)
                        .WithMany()
                        .HasForeignKey("SelectedByUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Data.Subject", null)
                        .WithMany()
                        .HasForeignKey("SelectedSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDataAccessLibrary.Data.Announcement", b =>
                {
                    b.Navigation("RelatedResources");
                });
#pragma warning restore 612, 618
        }
    }
}
