using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class Add16Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Elegant golden ring");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Rings", "Luxury diamond ring", "/imgs/ring2.jpg", "Diamond Ring", 450m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Rings", "Beautiful silver ring", "/imgs/ring3.jpg", "Silver Ring", 180m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Rings", "Premium royal ring", "/imgs/ring4.jpg", "Royal Ring", 600m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Glamora", "Necklaces", "Premium diamond necklace", "/imgs/necklace1.jpg", "Diamond Necklace", 500m },
                    { 6, "Glamora", "Necklaces", "Elegant gold necklace", "/imgs/necklace2.jpg", "Gold Necklace", 700m },
                    { 7, "Glamora", "Necklaces", "Classic pearl necklace", "/imgs/necklace3.jpg", "Pearl Necklace", 350m },
                    { 8, "Glamora", "Necklaces", "Luxury necklace", "/imgs/necklace4.jpg", "Luxury Necklace", 900m },
                    { 9, "Glamora", "Earrings", "Elegant diamond earrings", "/imgs/earring1.jpg", "Diamond Earrings", 300m },
                    { 10, "Glamora", "Earrings", "Beautiful gold earrings", "/imgs/earring2.jpg", "Gold Earrings", 250m },
                    { 11, "Glamora", "Earrings", "Classic pearl earrings", "/imgs/earring3.jpg", "Pearl Earrings", 200m },
                    { 12, "Glamora", "Earrings", "Premium luxury earrings", "/imgs/earring4.jpg", "Luxury Earrings", 550m },
                    { 13, "Glamora", "Watches", "Elegant classic watch", "/imgs/watch1.jpg", "Classic Watch", 700m },
                    { 14, "Glamora", "Watches", "Luxury gold watch", "/imgs/watch2.jpg", "Gold Watch", 1000m },
                    { 15, "Glamora", "Watches", "Modern silver watch", "/imgs/watch3.jpg", "Silver Watch", 650m },
                    { 16, "Glamora", "Watches", "Premium luxury watch", "/imgs/watch4.jpg", "Premium Watch", 1200m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Elegant luxury golden ring");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Necklaces", "Premium diamond necklace", "/imgs/necklace1.jpg", "Diamond Necklace", 500m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Bracelets", "Beautiful luxury bracelet", "/imgs/bracelet1.jpg", "Luxury Bracelet", 300m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Watches", "Elegant classic watch", "/imgs/watch1.jpg", "Classic Watch", 700m });
        }
    }
}
