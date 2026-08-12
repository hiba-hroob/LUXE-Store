using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class UpdateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Glamora", "Rings", "Elegant luxury golden ring", "/imgs/ring1.jpg", "Golden Ring", 250m },
                    { 2, "Glamora", "Necklaces", "Premium diamond necklace", "/imgs/necklace1.jpg", "Diamond Necklace", 500m },
                    { 3, "Glamora", "Bracelets", "Beautiful luxury bracelet", "/imgs/bracelet1.jpg", "Luxury Bracelet", 300m },
                    { 4, "Glamora", "Watches", "Elegant classic watch", "/imgs/watch1.jpg", "Classic Watch", 700m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
