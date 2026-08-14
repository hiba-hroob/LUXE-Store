using Microsoft.EntityFrameworkCore;
using Webproject.Models;

namespace Webproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Favorite>()
    .HasIndex(f => new { f.UserId, f.ProductId })
    .IsUnique();

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Product)
                .WithMany()
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


           
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = 1,
                    FullName = "hibamoh",
                    Email = "hiba@gmail.com",
                    Password = "11234511"
                },

                new User
                {
                    Id = 2,
                    FullName = "mostafamoh",
                    Email = "mostafa123@gmail.com",
                    Password = "27134532"
                },

                new User
                {
                    Id = 3,
                    FullName = "Ahmadkhallel",
                    Email = "Ahmadkhallel@gmail.com",
                    Password = "37134533"
                },

                new User
                {
                    Id = 4,
                    FullName = "ranaahmad",
                    Email = "rana.123l@gmail.com",
                    Password = "54134564"
                }


            );


            // Products
            modelBuilder.Entity<Product>().HasData(

            
                new Product
                {
                    Id = 1,
                    Name = "Golden Ring",
                    Brand = "LUXE",
                    Category = "Rings",
                    Price = 250,
                    ImageUrl = "/imgs/ring1.jpg",
                    Description = "Elegant golden ring"
                },

                new Product
                {
                    Id = 2,
                    Name = "Diamond Ring",
                    Brand = "LUXE",
                    Category = "Rings",
                    Price = 450,
                    ImageUrl = "/imgs/ring2.jpg",
                    Description = "Luxury diamond ring"
                },

                new Product
                {
                    Id = 3,
                    Name = "Silver Ring",
                    Brand = "LUXE",
                    Category = "Rings",
                    Price = 180,
                    ImageUrl = "/imgs/ring3.jpg",
                    Description = "Beautiful silver ring"
                },

                new Product
                {
                    Id = 4,
                    Name = "Royal Ring",
                    Brand = "LUXE",
                    Category = "Rings",
                    Price = 600,
                    ImageUrl = "/imgs/ring4.jpg",
                    Description = "Premium royal ring"
                },


             
                new Product
                {
                    Id = 5,
                    Name = "Diamond Necklace",
                    Brand = "LUXE",
                    Category = "Necklaces",
                    Price = 500,
                    ImageUrl = "/imgs/necklace1.jpg",
                    Description = "Premium diamond necklace"
                },

                new Product
                {
                    Id = 6,
                    Name = "Gold Necklace",
                    Brand = "LUXE",
                    Category = "Necklaces",
                    Price = 700,
                    ImageUrl = "/imgs/necklace2.jpg",
                    Description = "Elegant gold necklace"
                },

                new Product
                {
                    Id = 7,
                    Name = "Pearl Necklace",
                    Brand = "LUXE",
                    Category = "Necklaces",
                    Price = 350,
                    ImageUrl = "/imgs/necklace3.jpg",
                    Description = "Classic pearl necklace"
                },

                new Product
                {
                    Id = 8,
                    Name = "Luxury Necklace",
                    Brand = "LUXE",
                    Category = "Necklaces",
                    Price = 900,
                    ImageUrl = "/imgs/necklace4.jpg",
                    Description = "Luxury necklace"
                },


            
                new Product
                {
                    Id = 9,
                    Name = "Diamond Earrings",
                    Brand = "LUXE",
                    Category = "Earrings",
                    Price = 300,
                    ImageUrl = "/imgs/earring1.jpg",
                    Description = "Elegant diamond earrings"
                },

                new Product
                {
                    Id = 10,
                    Name = "Gold Earrings",
                    Brand = "LUXE",
                    Category = "Earrings",
                    Price = 250,
                    ImageUrl = "/imgs/earring2.jpg",
                    Description = "Beautiful gold earrings"
                },

                new Product
                {
                    Id = 11,
                    Name = "Pearl Earrings",
                    Brand = "LUXE",
                    Category = "Earrings",
                    Price = 200,
                    ImageUrl = "/imgs/earring3.jpg",
                    Description = "Classic pearl earrings"
                },

                new Product
                {
                    Id = 12,
                    Name = "Luxury Earrings",
                    Brand = "LUXE",
                    Category = "Earrings",
                    Price = 550,
                    ImageUrl = "/imgs/earring4.jpg",
                    Description = "Premium luxury earrings"
                },


                
                new Product
                {
                    Id = 13,
                    Name = "Classic Watch",
                    Brand = "LUXE",
                    Category = "Watches",
                    Price = 700,
                    ImageUrl = "/imgs/watch1.jpg",
                    Description = "Elegant classic watch"
                },

                new Product
                {
                    Id = 14,
                    Name = "Gold Watch",
                    Brand = "LUXE",
                    Category = "Watches",
                    Price = 1000,
                    ImageUrl = "/imgs/watch2.jpg",
                    Description = "Luxury gold watch"
                },

                new Product
                {
                    Id = 15,
                    Name = "Silver Watch",
                    Brand = "LUXE",
                    Category = "Watches",
                    Price = 650,
                    ImageUrl = "/imgs/watch3.jpg",
                    Description = "Modern silver watch"
                },

                new Product
                {
                    Id = 16,
                    Name = "Premium Watch",
                    Brand = "LUXE",
                    Category = "Watches",
                    Price = 1200,
                    ImageUrl = "/imgs/watch4.jpg",
                    Description = "Premium luxury watch"
                },

new Product
{
    Id = 17,
    Name = "Golden Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 400,
    ImageUrl = "/imgs/bracelet1.jpg",
    Description = "Elegant golden bracelet"
},

new Product
{
    Id = 18,
    Name = "Diamond Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 750,
    ImageUrl = "/imgs/bracelet2.jpg",
    Description = "Luxury diamond bracelet"
},

new Product
{
    Id = 19,
    Name = "Silver Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 250,
    ImageUrl = "/imgs/bracelet3.jpg",
    Description = "Beautiful silver bracelet"
},

new Product
{
    Id = 20,
    Name = "Pearl Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 350,
    ImageUrl = "/imgs/bracelet4.jpg",
    Description = "Classic pearl bracelet"
},

new Product
{
    Id = 21,
    Name = "Royal Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 900,
    ImageUrl = "/imgs/bracelet5.jpg",
    Description = "Premium royal bracelet"
},

new Product
{
    Id = 22,
    Name = "Luxury Gold Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 650,
    ImageUrl = "/imgs/bracelet6.jpg",
    Description = "Luxury gold design"
},

new Product
{
    Id = 23,
    Name = "Crystal Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 500,
    ImageUrl = "/imgs/bracelet7.jpg",
    Description = "Elegant crystal bracelet"
},

new Product
{
    Id = 24,
    Name = "Classic Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 280,
    ImageUrl = "/imgs/bracelet8.jpg",
    Description = "Classic everyday bracelet"
},

new Product
{
    Id = 25,
    Name = "Diamond Gold Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 1200,
    ImageUrl = "/imgs/bracelet9.jpg",
    Description = "Exclusive diamond bracelet"
},

new Product
{
    Id = 26,
    Name = "Modern Bracelet",
    Brand = "LUXE",
    Category = "Bracelets",
    Price = 320,
    ImageUrl = "/imgs/bracelet10.jpg",
    Description = "Modern elegant bracelet"
},


new Product
{
    Id = 27,
    Name = "Heart Necklace",
    Brand = "LUXE",
    Category = "Necklaces",
    Price = 280,
    ImageUrl = "/imgs/necklace5.jpg",
    Description = "Beautiful heart necklace"
},

new Product
{
    Id = 28,
    Name = "Royal Necklace",
    Brand = "LUXE",
    Category = "Necklaces",
    Price = 1500,
    ImageUrl = "/imgs/necklace6.jpg",
    Description = "Royal diamond collection"
},

new Product
{
    Id = 29,
    Name = "Silver Pearl Necklace",
    Brand = "LUXE",
    Category = "Necklaces",
    Price = 450,
    ImageUrl = "/imgs/necklace7.jpg",
    Description = "Elegant pearl style"
},

new Product
{
    Id = 30,
    Name = "Vintage Necklace",
    Brand = "LUXE",
    Category = "Necklaces",
    Price = 600,
    ImageUrl = "/imgs/necklace8.jpg",
    Description = "Vintage luxury necklace"
},

new Product
{
    Id = 31,
    Name = " Diamond Necklace",
    Brand = "LUXE",
    Category = "Necklaces",
    Price = 1100,
    ImageUrl = "/imgs/necklace9.jpg",
    Description = "Classic diamond design"
},

new Product
{
    Id = 32,
    Name = "Rose Gold Necklace",
    Brand = "LUXE",
    Category = "Necklaces",
    Price = 800,
    ImageUrl = "/imgs/necklace10.jpg",
    Description = "Rose gold elegance"
},



new Product
{
    Id = 33,
    Name = "Luxury Black Watch",
    Brand = "LUXE",
    Category = "Watches",
    Price = 850,
    ImageUrl = "/imgs/watch5.jpg",
    Description = "Luxury black watch"
},

new Product
{
    Id = 34,
    Name = "Diamond Watch",
    Brand = "LUXE",
    Category = "Watches",
    Price = 1700,
    ImageUrl = "/imgs/watch6.jpg",
    Description = "Diamond premium watch"
},

new Product
{
    Id = 35,
    Name = "Classic Leather Watch",
    Brand = "LUXE",
    Category = "Watches",
    Price = 450,
    ImageUrl = "/imgs/watch7.jpg",
    Description = "Leather classic watch"
},

new Product
{
    Id = 36,
    Name = "Royal Gold Watch",
    Brand = "LUXE",
    Category = "Watches",
    Price = 2000,
    ImageUrl = "/imgs/watch8.jpg",
    Description = "Royal gold watch"
},



new Product
{
    Id = 37,
    Name = "Crystal Ring",
    Brand = "LUXE",
    Category = "Rings",
    Price = 320,
    ImageUrl = "/imgs/ring5.jpg",
    Description = "Elegant crystal ring"
},

new Product
{
    Id = 38,
    Name = "Rose Gold Ring",
    Brand = "LUXE",
    Category = "Rings",
    Price = 380,
    ImageUrl = "/imgs/ring6.jpg",
    Description = "Beautiful rose gold ring"
},

new Product
{
    Id = 39,
    Name = "Luxury Diamond Ring",
    Brand = "LUXE",
    Category = "Rings",
    Price = 850,
    ImageUrl = "/imgs/ring7.jpg",
    Description = "Premium diamond ring"
},

new Product
{
    Id = 40,
    Name = "Classic Silver Ring",
    Brand = "LUXE",
    Category = "Rings",
    Price = 220,
    ImageUrl = "/imgs/ring8.jpg",
    Description = "Classic silver ring"
},

new Product
{
    Id = 41,
    Name = "Royal Gold Ring",
    Brand = "LUXE",
    Category = "Rings",
    Price = 950,
    ImageUrl = "/imgs/ring9.jpg",
    Description = "Royal luxury ring"
},

new Product
{
    Id = 42,
    Name = "Vintage Ring",
    Brand = "LUXE",
    Category = "Rings",
    Price = 400,
    ImageUrl = "/imgs/ring10.jpg",
    Description = "Vintage elegant ring"
},



new Product
{
    Id = 43,
    Name = "Crystal Earrings",
    Brand = "LUXE",
    Category = "Earrings",
    Price = 280,
    ImageUrl = "/imgs/earring5.jpg",
    Description = "Elegant crystal earrings"
},

new Product
{
    Id = 44,
    Name = "Rose Gold Earrings",
    Brand = "LUXE",
    Category = "Earrings",
    Price = 420,
    ImageUrl = "/imgs/earring6.jpg",
    Description = "Beautiful rose gold earrings"
},

new Product
{
    Id = 45,
    Name = "Luxe Diamond Earrings",
    Brand = "LUXE",
    Category = "Earrings",
    Price = 850,
    ImageUrl = "/imgs/earring7.jpg",
    Description = "Premium diamond earrings"
},

new Product
{
    Id = 46,
    Name = "Golden Pearl Earrings",
    Brand = "LUXE",
    Category = "Earrings",
    Price = 500,
    ImageUrl = "/imgs/earring8.jpg",
    Description = "Classic pearl earrings"
},

new Product
{
    Id = 47,
    Name = "Royal Earrings",
    Brand = "LUXE",
    Category = "Earrings",
    Price = 900,
    ImageUrl = "/imgs/earring9.jpg",
    Description = "Royal luxury earrings"
},

new Product
{
    Id = 48,
    Name = "Vintage Earrings",
    Brand = "LUXE",
    Category = "Earrings",
    Price = 350,
    ImageUrl = "/imgs/earring10.jpg",
    Description = "Vintage elegant earrings"
},


new Product
{
    Id = 49,
    Name = "Luxury Silver Watch",
    Brand = "LUXE",
    Category = "Watches",
    Price = 900,
    ImageUrl = "/imgs/watch9.jpg",
    Description = "Elegant luxury silver watch"
},

new Product
{
    Id = 50,
    Name = "Diamond Royal Watch",
    Brand = "LUXE",
    Category = "Watches",
    Price = 2500,
    ImageUrl = "/imgs/watch10.jpg",
    Description = "Exclusive diamond royal watch"
}

            );
        }
    }
}