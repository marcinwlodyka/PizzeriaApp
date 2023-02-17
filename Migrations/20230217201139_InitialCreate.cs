using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzeriaApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Image", "Ingredients", "Name" },
                values: new object[,]
                {
                    { 1, "https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg", "ass", "test1" },
                    { 2, "https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg", "ass", "test2" },
                    { 3, "https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg", "ass", "test3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
