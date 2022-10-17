using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaServicios.API.Author.Migrations
{
    public partial class MigrationPostgresInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicDegreeE_BookAuthorE_AuthorIdBookAuthot",
                table: "AcademicDegreeE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorE",
                table: "BookAuthorE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicDegreeE",
                table: "AcademicDegreeE");

            migrationBuilder.RenameTable(
                name: "BookAuthorE",
                newName: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "AcademicDegreeE",
                newName: "AcademicDegree");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicDegreeE_AuthorIdBookAuthot",
                table: "AcademicDegree",
                newName: "IX_AcademicDegree_AuthorIdBookAuthot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                column: "IdBookAuthot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicDegree",
                table: "AcademicDegree",
                column: "IdAcademicDegree");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicDegree_BookAuthor_AuthorIdBookAuthot",
                table: "AcademicDegree",
                column: "AuthorIdBookAuthot",
                principalTable: "BookAuthor",
                principalColumn: "IdBookAuthot",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicDegree_BookAuthor_AuthorIdBookAuthot",
                table: "AcademicDegree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicDegree",
                table: "AcademicDegree");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BookAuthorE");

            migrationBuilder.RenameTable(
                name: "AcademicDegree",
                newName: "AcademicDegreeE");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicDegree_AuthorIdBookAuthot",
                table: "AcademicDegreeE",
                newName: "IX_AcademicDegreeE_AuthorIdBookAuthot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorE",
                table: "BookAuthorE",
                column: "IdBookAuthot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicDegreeE",
                table: "AcademicDegreeE",
                column: "IdAcademicDegree");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicDegreeE_BookAuthorE_AuthorIdBookAuthot",
                table: "AcademicDegreeE",
                column: "AuthorIdBookAuthot",
                principalTable: "BookAuthorE",
                principalColumn: "IdBookAuthot",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
