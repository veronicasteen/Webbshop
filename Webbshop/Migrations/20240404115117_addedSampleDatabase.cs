using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshop.Migrations
{
    public partial class addedSampleDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Account_AccountID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AccountID",
                table: "Products",
                newName: "IX_Products_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountID",
                table: "Products",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AccountID",
                table: "Product",
                newName: "IX_Product_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Account_AccountID",
                table: "Product",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
