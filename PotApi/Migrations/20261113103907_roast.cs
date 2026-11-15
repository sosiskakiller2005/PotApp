using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PotApp.Migrations
{
    /// <inheritdoc />
    public partial class roast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoastDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoastDegrees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_RoastDegreeId",
                table: "Products",
                column: "RoastDegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RoastDegrees_RoastDegreeId",
                table: "Products",
                column: "RoastDegreeId",
                principalTable: "RoastDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RoastDegrees_RoastDegreeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "RoastDegrees");

            migrationBuilder.DropIndex(
                name: "IX_Products_RoastDegreeId",
                table: "Products");
        }
    }
}
