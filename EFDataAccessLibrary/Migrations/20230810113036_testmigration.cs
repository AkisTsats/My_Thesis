using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Announcements_Title",
                table: "Announcements");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Announcements",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Title",
                keyValue: null,
                column: "Title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Announcements",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Announcements_Title",
                table: "Announcements",
                column: "Title");
        }
    }
}
