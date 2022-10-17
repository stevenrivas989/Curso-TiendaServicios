using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TiendaServicios.API.Autor.Migrations
{
    public partial class MigrationPostgresInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthorE",
                columns: table => new
                {
                    IdBookAuthot = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Bithdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BookAuthorGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorE", x => x.IdBookAuthot);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDegreeE",
                columns: table => new
                {
                    IdAcademicDegree = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AcademicCenter = table.Column<string>(type: "text", nullable: false),
                    DegreeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorLibroId = table.Column<int>(type: "integer", nullable: false),
                    AuthorIdBookAuthot = table.Column<int>(type: "integer", nullable: false),
                    AcademicDegreeGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegreeE", x => x.IdAcademicDegree);
                    table.ForeignKey(
                        name: "FK_AcademicDegreeE_BookAuthorE_AuthorIdBookAuthot",
                        column: x => x.AuthorIdBookAuthot,
                        principalTable: "BookAuthorE",
                        principalColumn: "IdBookAuthot",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDegreeE_AuthorIdBookAuthot",
                table: "AcademicDegreeE",
                column: "AuthorIdBookAuthot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegreeE");

            migrationBuilder.DropTable(
                name: "BookAuthorE");
        }
    }
}
