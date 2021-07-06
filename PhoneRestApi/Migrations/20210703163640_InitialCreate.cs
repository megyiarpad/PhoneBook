using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneRestApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneItems", x => x.ID);
                });
            migrationBuilder.InsertData(
                    table: "PhoneItems",
                    columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                    values: new object[,]
                    {
                        {"Test", "User", "+3620213123"},
                        {"Second", "Name", "+491576845876"}
                    }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneItems");
        }
    }
}
