using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class AddNewProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 17, "Glamora", "Bracelets", "Elegant golden bracelet", "/imgs/bracelet1.jpg", "Golden Bracelet", 400m },
                    { 18, "Glamora", "Bracelets", "Luxury diamond bracelet", "/imgs/bracelet2.jpg", "Diamond Bracelet", 750m },
                    { 19, "Glamora", "Bracelets", "Beautiful silver bracelet", "/imgs/bracelet3.jpg", "Silver Bracelet", 250m },
                    { 20, "Glamora", "Bracelets", "Classic pearl bracelet", "/imgs/bracelet4.jpg", "Pearl Bracelet", 350m },
                    { 21, "Glamora", "Bracelets", "Premium royal bracelet", "/imgs/bracelet5.jpg", "Royal Bracelet", 900m },
                    { 22, "Glamora", "Bracelets", "Luxury gold design", "/imgs/bracelet6.jpg", "Luxury Gold Bracelet", 650m },
                    { 23, "Glamora", "Bracelets", "Elegant crystal bracelet", "/imgs/bracelet7.jpg", "Crystal Bracelet", 500m },
                    { 24, "Glamora", "Bracelets", "Classic everyday bracelet", "/imgs/bracelet8.jpg", "Classic Bracelet", 280m },
                    { 25, "Glamora", "Bracelets", "Exclusive diamond bracelet", "/imgs/bracelet9.jpg", "Diamond Gold Bracelet", 1200m },
                    { 26, "Glamora", "Bracelets", "Modern elegant bracelet", "/imgs/bracelet10.jpg", "Modern Bracelet", 320m },
                    { 27, "Glamora", "Necklaces", "Beautiful heart necklace", "/imgs/necklace5.jpg", "Heart Necklace", 280m },
                    { 28, "Glamora", "Necklaces", "Royal diamond collection", "/imgs/necklace6.jpg", "Royal Diamond Necklace", 1500m },
                    { 29, "Glamora", "Necklaces", "Elegant pearl style", "/imgs/necklace7.jpg", "Silver Pearl Necklace", 450m },
                    { 30, "Glamora", "Necklaces", "Vintage luxury necklace", "/imgs/necklace8.jpg", "Vintage Necklace", 600m },
                    { 31, "Glamora", "Necklaces", "Classic diamond design", "/imgs/necklace9.jpg", "Classic Diamond Necklace", 1100m },
                    { 32, "Glamora", "Necklaces", "Rose gold elegance", "/imgs/necklace10.jpg", "Rose Gold Necklace", 800m },
                    { 33, "Glamora", "Watches", "Luxury black watch", "/imgs/watch5.jpg", "Luxury Black Watch", 850m },
                    { 34, "Glamora", "Watches", "Diamond premium watch", "/imgs/watch6.jpg", "Diamond Watch", 1700m },
                    { 35, "Glamora", "Watches", "Leather classic watch", "/imgs/watch7.jpg", "Classic Leather Watch", 450m },
                    { 36, "Glamora", "Watches", "Royal gold watch", "/imgs/watch8.jpg", "Royal Gold Watch", 2000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
