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
                        {"Second", "Name", "+491576845876"},
                        {"Alan", "Walker", "+3620213123"},
                        {"Alexander", "Sparrow", "+491576845876"},
                        {"Amelia", "Wattson", "+3620213123"},
                        {"Anie", "Winehouse", "+491576845876"},
                        {"Aurora", "Hunter", "+3620213123"},
                        {"Ava", "Max", "+491576845876"},
                        {"Barack", "Obama", "+3620213123"},
                        {"Benjamin", "Franklin", "+491576845876"},
                        {"Berna", "Cerna", "+3620213123"},
                        {"Elijah", "Name", "+491576845876"},
                        {"Test", "Big", "+3620213123"},
                        {"Henry", "Cavil", "+491576845876"},
                        {"Hugo", "Lel", "+3620213123"},
                        {"Isabella", "Michalson", "+491576845876"},
                        {"James", "Franko", "+3620213123"},
                        {"Michael", "Jackson", "+3620213123"},
                        {"Michael", "Obama", "+491576845876"},
                        {"Mike", "Baker", "+3620213123"},
                        {"Mila", "Nice", "+491576845876"},
                        {"Noah", "Avar", "+3620213123"},
                        {"Oliver", "Jackson", "+491576845876"},
                        {"Olivia", "Colman", "+3620213123"},
                        {"Peter", "Parker", "+491576845876"},
                        {"Quinn", "Lucas", "+3620213123"},
                        {"Liam", "Ava", "+491576845876"}
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
