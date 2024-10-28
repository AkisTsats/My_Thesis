using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Announcements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcademicYearsAnnouncement",
                columns: table => new
                {
                    RelatesToAcademicYearsId = table.Column<int>(type: "int", nullable: false),
                    RelatesToAnnouncementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYearsAnnouncement", x => new { x.RelatesToAcademicYearsId, x.RelatesToAnnouncementsId });
                    table.ForeignKey(
                        name: "FK_AcademicYearsAnnouncement_AcademicYears_RelatesToAcademicYea~",
                        column: x => x.RelatesToAcademicYearsId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicYearsAnnouncement_Announcements_RelatesToAnnouncemen~",
                        column: x => x.RelatesToAnnouncementsId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcademicYearsUser",
                columns: table => new
                {
                    SelectedAcademicYearsId = table.Column<int>(type: "int", nullable: false),
                    SelectedByUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYearsUser", x => new { x.SelectedAcademicYearsId, x.SelectedByUsersId });
                    table.ForeignKey(
                        name: "FK_AcademicYearsUser_AcademicYears_SelectedAcademicYearsId",
                        column: x => x.SelectedAcademicYearsId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicYearsUser_Users_SelectedByUsersId",
                        column: x => x.SelectedByUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYearsAnnouncement_RelatesToAnnouncementsId",
                table: "AcademicYearsAnnouncement",
                column: "RelatesToAnnouncementsId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYearsUser_SelectedByUsersId",
                table: "AcademicYearsUser",
                column: "SelectedByUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicYearsAnnouncement");

            migrationBuilder.DropTable(
                name: "AcademicYearsUser");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Announcements");
        }
    }
}
