using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class fixcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_categorieslistuser_CategoryID",
                table: "categorieslistuser",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorieslistuser");
        }
    }
}
