using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
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
                    YearsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YList", x => x.YearsID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abstract = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Alert = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Author = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnID);
                    table.UniqueConstraint("AK_Announcements_Title", x => x.Title);
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
                    InMail = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InBrowser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InPhone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PauseOneHour = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PauseOneDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PauseAlert = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                    YearsListYearsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserYearsList", x => new { x.UsersUserID, x.YearsListYearsID });
                    table.ForeignKey(
                        name: "FK_UserYearsList_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserYearsList_YList_YearsListYearsID",
                        column: x => x.YearsListYearsID,
                        principalTable: "YList",
                        principalColumn: "YearsID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserID",
                table: "Announcements",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserYearsList_YearsListYearsID",
                table: "UserYearsList",
                column: "YearsListYearsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "UserYearsList");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "YList");
        }
    }
}
