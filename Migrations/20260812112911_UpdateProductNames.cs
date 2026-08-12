using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class UpdateProductNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Royal Necklace");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: " Diamond Necklace");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Luxe Diamond Earrings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Royal Diamond Necklace");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Classic Diamond Necklace");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Luxury Diamond Earrings");
        }
    }
}
