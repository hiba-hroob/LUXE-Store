using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class AddFiftyProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 37, "Glamora", "Rings", "Elegant crystal ring", "/imgs/ring5.jpg", "Crystal Ring", 320m },
                    { 38, "Glamora", "Rings", "Beautiful rose gold ring", "/imgs/ring6.jpg", "Rose Gold Ring", 380m },
                    { 39, "Glamora", "Rings", "Premium diamond ring", "/imgs/ring7.jpg", "Luxury Diamond Ring", 850m },
                    { 40, "Glamora", "Rings", "Classic silver ring", "/imgs/ring8.jpg", "Classic Silver Ring", 220m },
                    { 41, "Glamora", "Rings", "Royal luxury ring", "/imgs/ring9.jpg", "Royal Gold Ring", 950m },
                    { 42, "Glamora", "Rings", "Vintage elegant ring", "/imgs/ring10.jpg", "Vintage Ring", 400m },
                    { 43, "Glamora", "Earrings", "Elegant crystal earrings", "/imgs/earring5.jpg", "Crystal Earrings", 280m },
                    { 44, "Glamora", "Earrings", "Beautiful rose gold earrings", "/imgs/earring6.jpg", "Rose Gold Earrings", 420m },
                    { 45, "Glamora", "Earrings", "Premium diamond earrings", "/imgs/earring7.jpg", "Luxury Diamond Earrings", 850m },
                    { 46, "Glamora", "Earrings", "Classic pearl earrings", "/imgs/earring8.jpg", "Golden Pearl Earrings", 500m },
                    { 47, "Glamora", "Earrings", "Royal luxury earrings", "/imgs/earring9.jpg", "Royal Earrings", 900m },
                    { 48, "Glamora", "Earrings", "Vintage elegant earrings", "/imgs/earring10.jpg", "Vintage Earrings", 350m },
                    { 49, "Glamora", "Watches", "Elegant luxury silver watch", "/imgs/watch9.jpg", "Luxury Silver Watch", 900m },
                    { 50, "Glamora", "Watches", "Exclusive diamond royal watch", "/imgs/watch10.jpg", "Diamond Royal Watch", 2500m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
