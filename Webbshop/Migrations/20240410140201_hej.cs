using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshop.Migrations
{
    public partial class hej : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "AccountProducts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProducts", x => new { x.AccountID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_AccountProducts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountProducts_ProductID",
                table: "AccountProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProducts");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountID",
                table: "Products",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountID",
                table: "Products",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID");
        }
    }
}
