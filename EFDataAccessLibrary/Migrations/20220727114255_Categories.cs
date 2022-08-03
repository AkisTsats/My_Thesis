using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesList_Users_UserID",
                table: "CategoriesList");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsList_Users_UserID",
                table: "SubjectsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectsList",
                table: "SubjectsList");

            migrationBuilder.DropIndex(
                name: "IX_SubjectsList_UserID",
                table: "SubjectsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesList",
                table: "CategoriesList");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesList_UserID",
                table: "CategoriesList");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "SubjectsList");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "CategoriesList");

            migrationBuilder.RenameTable(
                name: "SubjectsList",
                newName: "SList");

            migrationBuilder.RenameTable(
                name: "CategoriesList",
                newName: "CList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SList",
                table: "SList",
                column: "SubjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CList",
                table: "CList",
                column: "CategoryID");

            migrationBuilder.CreateTable(
                name: "CategoriesListUser",
                columns: table => new
                {
                    CategoriesListCategoryID = table.Column<int>(type: "int", nullable: false),
                    UsersUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesListUser", x => new { x.CategoriesListCategoryID, x.UsersUserID });
                    table.ForeignKey(
                        name: "FK_CategoriesListUser_CList_CategoriesListCategoryID",
                        column: x => x.CategoriesListCategoryID,
                        principalTable: "CList",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesListUser_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubjectsListUser",
                columns: table => new
                {
                    SubjectsListSubjectID = table.Column<int>(type: "int", nullable: false),
                    UsersUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsListUser", x => new { x.SubjectsListSubjectID, x.UsersUserID });
                    table.ForeignKey(
                        name: "FK_SubjectsListUser_SList_SubjectsListSubjectID",
                        column: x => x.SubjectsListSubjectID,
                        principalTable: "SList",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsListUser_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesListUser_UsersUserID",
                table: "CategoriesListUser",
                column: "UsersUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsListUser_UsersUserID",
                table: "SubjectsListUser",
                column: "UsersUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesListUser");

            migrationBuilder.DropTable(
                name: "SubjectsListUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SList",
                table: "SList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CList",
                table: "CList");

            migrationBuilder.RenameTable(
                name: "SList",
                newName: "SubjectsList");

            migrationBuilder.RenameTable(
                name: "CList",
                newName: "CategoriesList");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "SubjectsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "CategoriesList",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectsList",
                table: "SubjectsList",
                column: "SubjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesList",
                table: "CategoriesList",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsList_UserID",
                table: "SubjectsList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesList_UserID",
                table: "CategoriesList",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesList_Users_UserID",
                table: "CategoriesList",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsList_Users_UserID",
                table: "SubjectsList",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
