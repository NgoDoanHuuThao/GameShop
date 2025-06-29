using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameShop.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Details", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Asia", "https://www.tncstore.vn/media/product/9765-79260_dia_game_ps5_the_last_of_u.jpg", true, "Đĩa game PS5 - The Last of Us II Remastered", 1749000m },
                    { 2, "ASIA", "https://www.tncstore.vn/media/product/250-10454-tnc-store-dia-game-ps5-stellar-blade-asia--2-.jpg", false, "Đĩa Game PS5 Stellar Blade", 1649000m },
                    { 3, "US", "https://hanoicomputercdn.com/media/product/69737_dia_game_ps5_grand_theft_auto_5_us.jpg", true, "Đĩa game PS5 - Grand Theft Auto 5", 699000m },
                    { 4, "Asia", "https://hanoicomputercdn.com/media/product/73999_dia_game_ps4_iron_man_vr_asia.jpg", false, "Đĩa game PS4 - Iron Man VR", 1000000m },
                    { 5, "EU", "https://hanoicomputercdn.com/media/product/72973_dia_game_ps4_street_fighter_6_eu.jpg", true, "Đĩa game PS4 - Street Fighter 6", 699000m },
                    { 6, "SW070", "https://product.hstatic.net/1000231532/product/super_mario_party_cho_nintendo_switch_master.jpg", false, "Super Mario Party cho Nintendo Switch", 1380000m }
                });
        }

        /// <inheritdoc />
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
