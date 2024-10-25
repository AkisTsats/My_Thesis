using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class vnext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    TotalAnnouncements = table.Column<int>(type: "int", nullable: false),
                    TotalUsers = table.Column<int>(type: "int", nullable: false),
                    TodayAnnouncements = table.Column<int>(type: "int", nullable: false),
                    TodayPeakUsers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrimaryEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondaryEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnrollmentYear = table.Column<int>(type: "int", nullable: false),
                    CurrentYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "YList",
                columns: table => new
                {
                    YearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YList", x => x.YearID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abstract = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Alert = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Author = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnID);
                    table.ForeignKey(
                        name: "FK_Announcements_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    canPostAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canSeePubAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canSeeMyAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canEditMyAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canDeleteMyAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canEditNotifications = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canEditMyYears = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canEditMySubjects = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canPostInfo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SOS = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    selectCategory = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    selectSubject = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canSeeAllAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canEditAllAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canAcceptAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canSeeStats = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canDeleteAllAnn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canAddCategories = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canAddSubjects = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InMail = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    InBrowser = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    InPhone = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PauseOneHour = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PauseOneDay = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PauseAlert = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserYearsList",
                columns: table => new
                {
                    UsersUserID = table.Column<int>(type: "int", nullable: false),
                    YearsListYearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserYearsList", x => new { x.UsersUserID, x.YearsListYearID });
                    table.ForeignKey(
                        name: "FK_UserYearsList_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserYearsList_YList_YearsListYearID",
                        column: x => x.YearsListYearID,
                        principalTable: "YList",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CList",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnnouncementAnnID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CList", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_CList_Announcements_AnnouncementAnnID",
                        column: x => x.AnnouncementAnnID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID");
                    table.ForeignKey(
                        name: "FK_CList_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPrimaryImage = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AnnouncementAnnID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Files_Announcements_AnnouncementAnnID",
                        column: x => x.AnnouncementAnnID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SList",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnnouncementAnnID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SList", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_SList_Announcements_AnnouncementAnnID",
                        column: x => x.AnnouncementAnnID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID");
                    table.ForeignKey(
                        name: "FK_SList_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoriesListannouncement",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AnnouncementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriesListannouncement", x => new { x.AnnouncementID, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_categoriesListannouncement_Announcements_AnnouncementID",
                        column: x => x.AnnouncementID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriesListannouncement_CList_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CList",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categorieslistuser",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorieslistuser", x => new { x.UserID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_categorieslistuser_CList_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CList",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categorieslistuser_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subjectsListannouncement",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AnnouncementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectsListannouncement", x => new { x.AnnouncementID, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_subjectsListannouncement_Announcements_AnnouncementID",
                        column: x => x.AnnouncementID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjectsListannouncement_SList_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SList",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subjectslistuser",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectslistuser", x => new { x.UserID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_subjectslistuser_SList_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SList",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjectslistuser_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserID",
                table: "Announcements",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_categoriesListannouncement_CategoryId",
                table: "categoriesListannouncement",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categorieslistuser_CategoryID",
                table: "categorieslistuser",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CList_AnnouncementAnnID",
                table: "CList",
                column: "AnnouncementAnnID");

            migrationBuilder.CreateIndex(
                name: "IX_CList_UserID",
                table: "CList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AnnouncementAnnID",
                table: "Files",
                column: "AnnouncementAnnID");

            migrationBuilder.CreateIndex(
                name: "IX_SList_AnnouncementAnnID",
                table: "SList",
                column: "AnnouncementAnnID");

            migrationBuilder.CreateIndex(
                name: "IX_SList_UserID",
                table: "SList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_subjectsListannouncement_SubjectId",
                table: "subjectsListannouncement",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_subjectslistuser_SubjectID",
                table: "subjectslistuser",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserYearsList_YearsListYearID",
                table: "UserYearsList",
                column: "YearsListYearID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriesListannouncement");

            migrationBuilder.DropTable(
                name: "categorieslistuser");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "subjectsListannouncement");

            migrationBuilder.DropTable(
                name: "subjectslistuser");

            migrationBuilder.DropTable(
                name: "UserYearsList");

            migrationBuilder.DropTable(
                name: "CList");

            migrationBuilder.DropTable(
                name: "SList");

            migrationBuilder.DropTable(
                name: "YList");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
