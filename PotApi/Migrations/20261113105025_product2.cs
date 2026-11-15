using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PotApp.Migrations
{
    /// <inheritdoc />
    public partial class product2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubscriptionProducts_SubscriptionProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubscriptionProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubscriptionProductId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionProducts_ProductId",
                table: "SubscriptionProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionProducts_Products_ProductId",
                table: "SubscriptionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionProducts_Products_ProductId",
                table: "SubscriptionProducts");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionProducts_ProductId",
                table: "SubscriptionProducts");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionProductId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubscriptionProductId",
                table: "Products",
                column: "SubscriptionProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubscriptionProducts_SubscriptionProductId",
                table: "Products",
                column: "SubscriptionProductId",
                principalTable: "SubscriptionProducts",
                principalColumn: "Id");
        }
    }
}
