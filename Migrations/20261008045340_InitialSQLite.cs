using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class InitialSQLite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    WalletBalance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFromAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "LUXE", "Rings", "Elegant golden ring", "/imgs/ring1.jpg", "Golden Ring", 250m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "LUXE", "Rings", "Luxury diamond ring", "/imgs/ring2.jpg", "Diamond Ring", 450m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "LUXE", "Rings", "Beautiful silver ring", "/imgs/ring3.jpg", "Silver Ring", 180m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 4, "LUXE", "Rings", "Premium royal ring", "/imgs/ring4.jpg", "Royal Ring", 600m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 5, "LUXE", "Necklaces", "Premium diamond necklace", "/imgs/necklace1.jpg", "Diamond Necklace", 500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 6, "LUXE", "Necklaces", "Elegant gold necklace", "/imgs/necklace2.jpg", "Gold Necklace", 700m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 7, "LUXE", "Necklaces", "Classic pearl necklace", "/imgs/necklace3.jpg", "Pearl Necklace", 350m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 8, "LUXE", "Necklaces", "Luxury necklace", "/imgs/necklace4.jpg", "Luxury Necklace", 900m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 9, "LUXE", "Earrings", "Elegant diamond earrings", "/imgs/earring1.jpg", "Diamond Earrings", 300m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 10, "LUXE", "Earrings", "Beautiful gold earrings", "/imgs/earring2.jpg", "Gold Earrings", 250m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 11, "LUXE", "Earrings", "Classic pearl earrings", "/imgs/earring3.jpg", "Pearl Earrings", 200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 12, "LUXE", "Earrings", "Premium luxury earrings", "/imgs/earring4.jpg", "Luxury Earrings", 550m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 13, "LUXE", "Watches", "Elegant classic watch", "/imgs/watch1.jpg", "Classic Watch", 700m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 14, "LUXE", "Watches", "Luxury gold watch", "/imgs/watch2.jpg", "Gold Watch", 1000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 15, "LUXE", "Watches", "Modern silver watch", "/imgs/watch3.jpg", "Silver Watch", 650m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 16, "LUXE", "Watches", "Premium luxury watch", "/imgs/watch4.jpg", "Premium Watch", 1200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 17, "LUXE", "Bracelets", "Elegant golden bracelet", "/imgs/bracelet1.jpg", "Golden Bracelet", 400m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 18, "LUXE", "Bracelets", "Luxury diamond bracelet", "/imgs/bracelet2.jpg", "Diamond Bracelet", 750m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 19, "LUXE", "Bracelets", "Beautiful silver bracelet", "/imgs/bracelet3.jpg", "Silver Bracelet", 250m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 20, "LUXE", "Bracelets", "Classic pearl bracelet", "/imgs/bracelet4.jpg", "Pearl Bracelet", 350m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 21, "LUXE", "Bracelets", "Premium royal bracelet", "/imgs/bracelet5.jpg", "Royal Bracelet", 900m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 22, "LUXE", "Bracelets", "Luxury gold design", "/imgs/bracelet6.jpg", "Luxury Gold Bracelet", 650m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 23, "LUXE", "Bracelets", "Elegant crystal bracelet", "/imgs/bracelet7.jpg", "Crystal Bracelet", 500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 24, "LUXE", "Bracelets", "Classic everyday bracelet", "/imgs/bracelet8.jpg", "Classic Bracelet", 280m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 25, "LUXE", "Bracelets", "Exclusive diamond bracelet", "/imgs/bracelet9.jpg", "Diamond Gold Bracelet", 1200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 26, "LUXE", "Bracelets", "Modern elegant bracelet", "/imgs/bracelet10.jpg", "Modern Bracelet", 320m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 27, "LUXE", "Necklaces", "Beautiful heart necklace", "/imgs/necklace5.jpg", "Heart Necklace", 280m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 28, "LUXE", "Necklaces", "Royal diamond collection", "/imgs/necklace6.jpg", "Royal Necklace", 1500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 29, "LUXE", "Necklaces", "Elegant pearl style", "/imgs/necklace7.jpg", "Silver Pearl Necklace", 450m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 30, "LUXE", "Necklaces", "Vintage luxury necklace", "/imgs/necklace8.jpg", "Vintage Necklace", 600m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 31, "LUXE", "Necklaces", "Classic diamond design", "/imgs/necklace9.jpg", " Diamond Necklace", 1100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 32, "LUXE", "Necklaces", "Rose gold elegance", "/imgs/necklace10.jpg", "Rose Gold Necklace", 800m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 33, "LUXE", "Watches", "Luxury black watch", "/imgs/watch5.jpg", "Luxury Black Watch", 850m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 34, "LUXE", "Watches", "Diamond premium watch", "/imgs/watch6.jpg", "Diamond Watch", 1700m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 35, "LUXE", "Watches", "Leather classic watch", "/imgs/watch7.jpg", "Classic Leather Watch", 450m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 36, "LUXE", "Watches", "Royal gold watch", "/imgs/watch8.jpg", "Royal Gold Watch", 2000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 37, "LUXE", "Rings", "Elegant crystal ring", "/imgs/ring5.jpg", "Crystal Ring", 320m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 38, "LUXE", "Rings", "Beautiful rose gold ring", "/imgs/ring6.jpg", "Rose Gold Ring", 380m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 39, "LUXE", "Rings", "Premium diamond ring", "/imgs/ring7.jpg", "Luxury Diamond Ring", 850m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 40, "LUXE", "Rings", "Classic silver ring", "/imgs/ring8.jpg", "Classic Silver Ring", 220m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 41, "LUXE", "Rings", "Royal luxury ring", "/imgs/ring9.jpg", "Royal Gold Ring", 950m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 42, "LUXE", "Rings", "Vintage elegant ring", "/imgs/ring10.jpg", "Vintage Ring", 400m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 43, "LUXE", "Earrings", "Elegant crystal earrings", "/imgs/earring5.jpg", "Crystal Earrings", 280m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 44, "LUXE", "Earrings", "Beautiful rose gold earrings", "/imgs/earring6.jpg", "Rose Gold Earrings", 420m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 45, "LUXE", "Earrings", "Premium diamond earrings", "/imgs/earring7.jpg", "Luxe Diamond Earrings", 850m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 46, "LUXE", "Earrings", "Classic pearl earrings", "/imgs/earring8.jpg", "Golden Pearl Earrings", 500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 47, "LUXE", "Earrings", "Royal luxury earrings", "/imgs/earring9.jpg", "Royal Earrings", 900m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 48, "LUXE", "Earrings", "Vintage elegant earrings", "/imgs/earring10.jpg", "Vintage Earrings", 350m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 49, "LUXE", "Watches", "Elegant luxury silver watch", "/imgs/watch9.jpg", "Luxury Silver Watch", 900m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 50, "LUXE", "Watches", "Exclusive diamond royal watch", "/imgs/watch10.jpg", "Diamond Royal Watch", 2500m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "WalletBalance" },
                values: new object[] { 1, "hiba@gmail.com", "hibamoh", "11234511", 0m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "WalletBalance" },
                values: new object[] { 2, "mostafa123@gmail.com", "mostafamoh", "27134532", 0m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "WalletBalance" },
                values: new object[] { 3, "Ahmadkhallel@gmail.com", "Ahmadkhallel", "37134533", 0m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "WalletBalance" },
                values: new object[] { 4, "rana.123l@gmail.com", "ranaahmad", "54134564", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId_ProductId",
                table: "Favorites",
                columns: new[] { "UserId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
