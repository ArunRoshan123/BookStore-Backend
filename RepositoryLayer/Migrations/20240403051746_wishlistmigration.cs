using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class wishlistmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishListTable",
                columns: table => new
                {
                    WishListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Book_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListTable", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_WishListTable_BookTable_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "BookTable",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListTable_UserTables_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTables",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishListTable_Book_Id",
                table: "WishListTable",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WishListTable_UserId",
                table: "WishListTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishListTable");
        }
    }
}
