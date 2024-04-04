using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class cartmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    Cart_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Book_Id = table.Column<int>(nullable: false),
                    Cart_Quantity = table.Column<int>(nullable: false),
                    IsPurchase = table.Column<bool>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.Cart_Id);
                    table.ForeignKey(
                        name: "FK_CartTable_BookTable_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "BookTable",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartTable_UserTables_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTables",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartTable_Book_Id",
                table: "CartTable",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CartTable_UserId",
                table: "CartTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartTable");
        }
    }
}
