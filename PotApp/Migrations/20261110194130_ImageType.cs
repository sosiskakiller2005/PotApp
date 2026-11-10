using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PotApp.Migrations
{
    /// <inheritdoc />
    public partial class ImageType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageTypes_ImageTypes_ImageTypeId",
                table: "ImageTypes");

            migrationBuilder.DropIndex(
                name: "IX_ImageTypes_ImageTypeId",
                table: "ImageTypes");

            migrationBuilder.DropColumn(
                name: "ImageTypeId",
                table: "ImageTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageTypeId",
                table: "Products",
                column: "ImageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImageTypes_ImageTypeId",
                table: "Products",
                column: "ImageTypeId",
                principalTable: "ImageTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImageTypes_ImageTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageTypeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ImageTypeId",
                table: "ImageTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_ImageTypeId",
                table: "ImageTypes",
                column: "ImageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageTypes_ImageTypes_ImageTypeId",
                table: "ImageTypes",
                column: "ImageTypeId",
                principalTable: "ImageTypes",
                principalColumn: "Id");
        }
    }
}
