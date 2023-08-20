using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class addfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnouncementCategoriesList",
                columns: table => new
                {
                    AnnouncementsAnnID = table.Column<int>(type: "int", nullable: false),
                    CategoriesListCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementCategoriesList", x => new { x.AnnouncementsAnnID, x.CategoriesListCategoryID });
                    table.ForeignKey(
                        name: "FK_AnnouncementCategoriesList_Announcements_AnnouncementsAnnID",
                        column: x => x.AnnouncementsAnnID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementCategoriesList_CList_CategoriesListCategoryID",
                        column: x => x.CategoriesListCategoryID,
                        principalTable: "CList",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoriesListannouncement",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    AnnouncementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriesListannouncement", x => new { x.AnnouncementID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_categoriesListannouncement_Announcements_AnnouncementID",
                        column: x => x.AnnouncementID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriesListannouncement_CList_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CList",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Images_Announcements_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Announcements",
                        principalColumn: "AnnID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementCategoriesList_CategoriesListCategoryID",
                table: "AnnouncementCategoriesList",
                column: "CategoriesListCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_categoriesListannouncement_CategoryID",
                table: "categoriesListannouncement",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AnnouncementAnnID",
                table: "Files",
                column: "AnnouncementAnnID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementCategoriesList");

            migrationBuilder.DropTable(
                name: "categoriesListannouncement");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
