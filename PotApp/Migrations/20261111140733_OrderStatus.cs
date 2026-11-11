using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PotApp.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuses_OrderStatuses_OrderStatusId",
                table: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_OrderStatuses_OrderStatusId",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "OrderStatuses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "OrderStatuses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_OrderStatusId",
                table: "OrderStatuses",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuses_OrderStatuses_OrderStatusId",
                table: "OrderStatuses",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }
    }
}
