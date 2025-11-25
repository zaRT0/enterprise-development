using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ModelName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ManufacturerName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                AircraftModelId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AircraftFamilys", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Passengers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                PassportNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                PassengerId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Passengers", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AircraftModels",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FlightRange = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                PassengerCapacity = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                CargoCapacity = table.Column<float>(type: "float", maxLength: 2, nullable: false),
                ModelFamilyId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AircraftModels", x => x.Id);
                table.ForeignKey(
                    name: "FK_AircraftModels_AircraftFamilys_ModelFamilyId",
                    column: x => x.ModelFamilyId,
                    principalTable: "AircraftFamilys",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Flights",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                DeparturePoint = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ArrivalPoint = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                DepartureDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ArrivalDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                AircraftModelId = table.Column<int>(type: "int", nullable: false),
                FlightId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Flights", x => x.Id);
                table.ForeignKey(
                    name: "FK_Flights_AircraftModels_AircraftModelId",
                    column: x => x.AircraftModelId,
                    principalTable: "AircraftModels",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Tickets",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                FlightId = table.Column<int>(type: "int", nullable: false),
                PassengerId = table.Column<int>(type: "int", nullable: false),
                SeatNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsHandLuggage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                TotalBaggageWeight = table.Column<float>(type: "float", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tickets", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tickets_Flights_FlightId",
                    column: x => x.FlightId,
                    principalTable: "Flights",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Tickets_Passengers_PassengerId",
                    column: x => x.PassengerId,
                    principalTable: "Passengers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.InsertData(
            table: "Passengers",
            columns: new[] { "Id", "BirthDate", "FullName", "PassengerId", "PassportNumber" },
            values: new object[,]
            {
                { 1, new DateOnly(1985, 3, 12), "Ivanov Ivan Ivanovic", null, "4244-123456" },
                { 2, new DateOnly(1990, 7, 22), "Petrova Maria Sergeevna", null, "4244-234567" },
                { 3, new DateOnly(1978, 11, 5), "Sidorov Alexey Vladimirovich", null, "4244-345678" },
                { 4, new DateOnly(2000, 1, 30), "Kuznetsova Anna Olegovna", null, "4244-456789" },
                { 5, new DateOnly(1982, 9, 14), "Smirnov Dmitry Andreevich", null, "4202-567890" },
                { 6, new DateOnly(1995, 4, 18), "Popova Ekaterina Nikolaevna", null, "4201-678901" },
                { 7, new DateOnly(1970, 12, 25), "Volkov Sergey Pavlovich", null, "4568-789012" },
                { 8, new DateOnly(1988, 6, 9), "Morozova Olga Viktorovna", null, "4857-890123" },
                { 9, new DateOnly(1992, 8, 3), "Lebedev Artyom Yuryevich", null, "3618-524872" },
                { 10, new DateOnly(1997, 2, 14), "Novikova Daria Igorevna", null, "8574-658974" },
                { 11, new DateOnly(1983, 5, 10), "Abramov Nikolay Petrovich", null, "1111-111111" },
                { 12, new DateOnly(1991, 12, 3), "Belova Vera Stepanovna", null, "2222-222222" },
                { 13, new DateOnly(1987, 8, 22), "Grigoryev Maxim Igorevich", null, "3333-333333" },
                { 14, new DateOnly(1999, 3, 17), "Dmitrieva Sofya Andreevna", null, "4444-444444" },
                { 15, new DateOnly(1975, 11, 30), "Efimov Roman Valeryevich", null, "5555-555555" },
                { 16, new DateOnly(1994, 7, 8), "Zhukova Polina Dmitrievna", null, "6666-666666" },
                { 17, new DateOnly(1989, 1, 15), "Zaitsev Ilya Olegovich", null, "7777-777777" },
                { 18, new DateOnly(1996, 9, 25), "Ivanova Kseniya Sergeevna", null, "8888-888888" },
                { 19, new DateOnly(1981, 4, 12), "Kozlov Vladislav Yuryevich", null, "9999-999999" },
                { 20, new DateOnly(1993, 6, 20), "Larionova Alina Viktorovna", null, "0041-125874" },
                { 21, new DateOnly(1986, 10, 5), "Makarov Daniil Pavlovich", null, "8547-123456" },
                { 22, new DateOnly(1998, 2, 28), "Nesterova Elizaveta Mikhailovna", null, "3657-234567" },
                { 23, new DateOnly(1992, 5, 15), "Preobrazhenskaya Daria Vyacheslavovna", null, "5241-658923" }
            });

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
