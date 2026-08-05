using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkingReservation.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ApplicantName", "EndTime", "ParkingSpaceId", "StartTime" },
                values: new object[,]
                {
                    { 1, "Kovács Péter", new DateTimeOffset(new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2026, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 2, "Nagy Anna", new DateTimeOffset(new DateTime(2026, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 2, new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
