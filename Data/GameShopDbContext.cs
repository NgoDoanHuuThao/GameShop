using GameShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GameShop.Data
{
    public class GameShopDbContext : DbContext      
    {
        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>().HasData
            (
                new Product { Id = 1, Name = "Đĩa game PS5 - The Last of Us II Remastered", Detail = "Asia", Price =1749000, ImageUrl = "https://www.tncstore.vn/media/product/9765-79260_dia_game_ps5_the_last_of_u.jpg", IsTrendingProduct = true },
                new Product { Id = 2, Name = "Đĩa Game PS5 Stellar Blade", Detail = "ASIA", Price = 1649000, ImageUrl = "https://www.tncstore.vn/media/product/250-10454-tnc-store-dia-game-ps5-stellar-blade-asia--2-.jpg", IsTrendingProduct = false },
                new Product { Id = 3, Name = "Đĩa game PS5 - Grand Theft Auto 5", Detail = "US", Price = 699000, ImageUrl = "https://hanoicomputercdn.com/media/product/69737_dia_game_ps5_grand_theft_auto_5_us.jpg", IsTrendingProduct = true },
                new Product { Id = 4, Name = "Đĩa game PS4 - Iron Man VR", Detail = "Asia", Price = 1000000, ImageUrl = "https://hanoicomputercdn.com/media/product/73999_dia_game_ps4_iron_man_vr_asia.jpg", IsTrendingProduct = false },
                new Product { Id = 5, Name = "Đĩa game PS4 - Street Fighter 6", Detail = "EU", Price = 699000, ImageUrl = "https://hanoicomputercdn.com/media/product/72973_dia_game_ps4_street_fighter_6_eu.jpg", IsTrendingProduct = true },
                new Product { Id = 6, Name = "Super Mario Party cho Nintendo Switch", Detail = "SW070", Price = 1380000, ImageUrl = "https://product.hstatic.net/1000231532/product/super_mario_party_cho_nintendo_switch_master.jpg", IsTrendingProduct = false }
            );
        }
    }

  
}

