using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MewMart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrize = table.Column<double>(type: "float", nullable: false),
                    Prize = table.Column<double>(type: "float", nullable: false),
                    Prize2 = table.Column<double>(type: "float", nullable: false),
                    Prize5 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ISBN", "ListPrize", "Manufacturer", "Prize", "Prize2", "Prize5", "Title" },
                values: new object[,]
                {
                    { 1, "Grön kattboll", "AB212", 25.0, "Made in China", 23.0, 21.0, 18.0, "Grön kattboll" },
                    { 2, "Röd kattboll", "AB213", 25.0, "Made in China", 23.0, 21.0, 18.0, "Röd kattboll" },
                    { 3, "Grön kattskål", "AC212", 25.0, "Made in China", 23.0, 21.0, 18.0, "Grön kattskål" },
                    { 4, "Röd kattskål", "AC213", 25.0, "Made in China", 23.0, 21.0, 18.0, "Röd kattskål" },
                    { 5, "Röd Tygleksak", "AD215", 25.0, "Made in China", 23.0, 21.0, 18.0, "Röd Tygleksak" },
                    { 6, "Grön Tygleksakl", "AD218", 25.0, "Made in China", 23.0, 21.0, 18.0, "Grön Tygleksak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
