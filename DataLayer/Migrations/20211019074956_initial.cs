using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cuisine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Cuisine", "Location", "Name" },
                values: new object[] { 1, 2, "Maryland", "Scott's Pizza" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Cuisine", "Location", "Name" },
                values: new object[] { 2, 2, "London", "Cinnamon Club" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Cuisine", "Location", "Name" },
                values: new object[] { 3, 1, "California", "La Costa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
