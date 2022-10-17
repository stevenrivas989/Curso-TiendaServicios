using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TiendaServicios.API.ShoppingCart.Migrations
{
    public partial class MigrationSqlServerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sessionCart",
                columns: table => new
                {
                    IdSessionCart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessionCart", x => x.IdSessionCart);
                });

            migrationBuilder.CreateTable(
                name: "sessionCartDetail",
                columns: table => new
                {
                    SessionCartDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SelectedProduct = table.Column<string>(type: "longtext", nullable: false),
                    SessionCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessionCartDetail", x => x.SessionCartDetailId);
                    table.ForeignKey(
                        name: "FK_sessionCartDetail_sessionCart_SessionCartId",
                        column: x => x.SessionCartId,
                        principalTable: "sessionCart",
                        principalColumn: "IdSessionCart",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sessionCartDetail_SessionCartId",
                table: "sessionCartDetail",
                column: "SessionCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sessionCartDetail");

            migrationBuilder.DropTable(
                name: "sessionCart");
        }
    }
}
