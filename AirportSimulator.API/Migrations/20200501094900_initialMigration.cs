using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSimulator.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FlightStateType = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOccupied = table.Column<bool>(nullable: false),
                    NextStations = table.Column<string>(nullable: true),
                    IsDepartureLastStation = table.Column<bool>(nullable: false),
                    IsLandingLastStation = table.Column<bool>(nullable: false),
                    IsLandingFirstStation = table.Column<bool>(nullable: false),
                    IsDepartureFirstStation = table.Column<bool>(nullable: false),
                    CurrentFlight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CurrentFlight", "IsDepartureFirstStation", "IsDepartureLastStation", "IsLandingFirstStation", "IsLandingLastStation", "IsOccupied", "NextStations" },
                values: new object[,]
                {
                    { 10, "", false, false, true, false, false, "2" },
                    { 1, "", false, false, true, false, false, "2" },
                    { 2, "", false, false, false, false, false, "3" },
                    { 3, "", false, false, false, false, false, "4" },
                    { 4, "", false, true, false, false, false, "5" },
                    { 5, "", false, false, false, false, false, "6;7" },
                    { 6, "", true, false, false, true, false, "8" },
                    { 7, "", true, false, false, true, false, "8" },
                    { 8, "", false, false, false, false, false, "4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
