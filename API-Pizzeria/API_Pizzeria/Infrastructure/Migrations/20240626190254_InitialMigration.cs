using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Delicious pizza with tomato sauce, mozzarella, and anchovies.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Napolitana", 10, 1000 },
                    { 2, "Classic pizza with tomato sauce, mozzarella, and fresh basil.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Margherita", 8, 1000 },
                    { 3, "Pizza with tomato sauce, mozzarella, and spicy pepperoni.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Pepperoni", 12, 1000 },
                    { 4, "Tropical pizza with tomato sauce, mozzarella, ham, and pineapple.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Hawaiian", 11, 1000 },
                    { 5, "Pizza with mozzarella, cheddar, parmesan, and gorgonzola.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Four Cheese", 13, 1000 },
                    { 6, "Pizza with tomato sauce, mozzarella, mushrooms, peppers, and onions.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Vegetarian", 9, 1000 },
                    { 7, "Pizza with BBQ sauce, mozzarella, shredded chicken, onions, and corn.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Barbecue", 14, 1000 },
                    { 8, "Pizza with tomato sauce, mozzarella, mussels, clams, and shrimp.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Seafood", 15, 1000 },
                    { 9, "Pizza with tomato sauce, mozzarella, and spicy Italian sausage.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Spicy Sausage", 13, 1000 },
                    { 10, "Pizza with truffle cream, mozzarella, and assorted mushrooms.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Truffle Mushroom", 16, 1000 },
                    { 11, "Pizza with buffalo sauce, mozzarella, and spicy chicken strips.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Buffalo Chicken", 14, 1000 },
                    { 12, "Pizza with pesto sauce, mozzarella, cherry tomatoes, and arugula.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Pesto Delight", 12, 1000 },
                    { 13, "Pizza with tomato sauce, mozzarella, jalapenos, and ground beef.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Mexican", 14, 1000 },
                    { 14, "Pizza with tomato sauce, mozzarella, and thinly sliced prosciutto.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Prosciutto", 15, 1000 },
                    { 15, "Pizza with tomato sauce, mozzarella, feta cheese, and black olives.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Greek", 13, 1000 },
                    { 16, "Pizza with tomato sauce, mozzarella, ham, mushrooms, and artichokes.", "https://i.postimg.cc/mkkxk6h5/ivan-torres-MQUqbmsz-GGM-unsplash.jpg", "Capricciosa", 14, 1000 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Password", "Rol", "UserName" },
                values: new object[,]
                {
                    { 1, "Nicolas123", "SuperAdmin", "Nicolas" },
                    { 2, "Anabella123", "SuperAdmin", "Anabella" },
                    { 3, "Delfina123", "SuperAdmin", "Delfina" },
                    { 5, "marta123", "Admin", "marta_admin" },
                    { 6, "johnAdmin123", "Admin", "john_admin" },
                    { 7, "janeAdmin123", "Admin", "jane_admin" },
                    { 8, "alice123", "Client", "alice" },
                    { 9, "bob123", "Client", "bob" },
                    { 10, "charlie123", "Client", "charlie" },
                    { 11, "dave123", "Client", "dave" },
                    { 12, "eve123", "Client", "eve" },
                    { 13, "frank123", "Client", "frank" },
                    { 14, "grace123", "Client", "grace" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
