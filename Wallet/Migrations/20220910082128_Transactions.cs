using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Wallet.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Sender = table.Column<string>(type: "text", nullable: true),
                    Addressee = table.Column<string>(type: "text", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CurrentUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_CurrentUserId",
                        column: x => x.CurrentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CurrentUserId",
                table: "Transaction",
                column: "CurrentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
