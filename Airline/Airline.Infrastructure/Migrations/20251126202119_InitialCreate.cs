using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airline.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AircraftFamilys",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                manufacturer_name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                AircraftModelId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AircraftFamilys", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Passengers",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                passport_number = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                full_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                PassengerId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Passengers", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AircraftModels",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                flight_range = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                passenger_capacity = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                cargo_capacity = table.Column<float>(type: "float", maxLength: 2, nullable: false),
                ModelFamilyId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AircraftModels", x => x.id);
                table.ForeignKey(
                    name: "FK_AircraftModels_AircraftFamilys_ModelFamilyId",
                    column: x => x.ModelFamilyId,
                    principalTable: "AircraftFamilys",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Flights",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                departure_point = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                arrival_point = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                departure_datetime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                arrival_datetime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                AircraftModelId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Flights", x => x.id);
                table.ForeignKey(
                    name: "FK_Flights_AircraftModels_AircraftModelId",
                    column: x => x.AircraftModelId,
                    principalTable: "AircraftModels",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Tickets",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                FlightId = table.Column<int>(type: "int", nullable: false),
                PassengerId = table.Column<int>(type: "int", nullable: false),
                seat_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                is_hand_luggage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                total_baggage_weight = table.Column<float>(type: "float", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tickets", x => x.id);
                table.ForeignKey(
                    name: "FK_Tickets_Flights_FlightId",
                    column: x => x.FlightId,
                    principalTable: "Flights",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Tickets_Passengers_PassengerId",
                    column: x => x.PassengerId,
                    principalTable: "Passengers",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_AircraftModels_ModelFamilyId",
            table: "AircraftModels",
            column: "ModelFamilyId");

        migrationBuilder.CreateIndex(
            name: "IX_Flights_AircraftModelId",
            table: "Flights",
            column: "AircraftModelId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_FlightId",
            table: "Tickets",
            column: "FlightId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_PassengerId",
            table: "Tickets",
            column: "PassengerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tickets");

        migrationBuilder.DropTable(
            name: "Flights");

        migrationBuilder.DropTable(
            name: "Passengers");

        migrationBuilder.DropTable(
            name: "AircraftModels");

        migrationBuilder.DropTable(
            name: "AircraftFamilys");
    }
}
