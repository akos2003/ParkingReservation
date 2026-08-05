using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkingReservation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataWith100Spaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 0);

            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 4, 0 },
                    { 5, 0 },
                    { 6, 0 },
                    { 7, 0 },
                    { 8, 0 },
                    { 9, 0 },
                    { 10, 0 },
                    { 11, 0 },
                    { 12, 0 },
                    { 13, 0 },
                    { 14, 0 },
                    { 15, 0 },
                    { 16, 0 },
                    { 17, 0 },
                    { 18, 0 },
                    { 19, 0 },
                    { 20, 0 },
                    { 21, 0 },
                    { 22, 0 },
                    { 23, 0 },
                    { 24, 0 },
                    { 25, 0 },
                    { 26, 0 },
                    { 27, 0 },
                    { 28, 0 },
                    { 29, 0 },
                    { 30, 0 },
                    { 31, 0 },
                    { 32, 0 },
                    { 33, 0 },
                    { 34, 0 },
                    { 35, 0 },
                    { 36, 0 },
                    { 37, 0 },
                    { 38, 0 },
                    { 39, 0 },
                    { 40, 0 },
                    { 41, 0 },
                    { 42, 0 },
                    { 43, 0 },
                    { 44, 0 },
                    { 45, 0 },
                    { 46, 0 },
                    { 47, 0 },
                    { 48, 0 },
                    { 49, 0 },
                    { 50, 0 },
                    { 51, 0 },
                    { 52, 0 },
                    { 53, 0 },
                    { 54, 0 },
                    { 55, 0 },
                    { 56, 0 },
                    { 57, 0 },
                    { 58, 0 },
                    { 59, 0 },
                    { 60, 0 },
                    { 61, 0 },
                    { 62, 0 },
                    { 63, 0 },
                    { 64, 0 },
                    { 65, 0 },
                    { 66, 0 },
                    { 67, 0 },
                    { 68, 0 },
                    { 69, 0 },
                    { 70, 0 },
                    { 71, 0 },
                    { 72, 0 },
                    { 73, 0 },
                    { 74, 0 },
                    { 75, 0 },
                    { 76, 0 },
                    { 77, 0 },
                    { 78, 0 },
                    { 79, 0 },
                    { 80, 0 },
                    { 81, 1 },
                    { 82, 1 },
                    { 83, 1 },
                    { 84, 1 },
                    { 85, 1 },
                    { 86, 1 },
                    { 87, 1 },
                    { 88, 1 },
                    { 89, 1 },
                    { 90, 1 },
                    { 91, 2 },
                    { 92, 2 },
                    { 93, 2 },
                    { 94, 2 },
                    { 95, 2 },
                    { 96, 2 },
                    { 97, 2 },
                    { 98, 2 },
                    { 99, 2 },
                    { 100, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicantName", "EndTime", "StartTime" },
                values: new object[] { "Teszt Felhasználó 1", new DateTimeOffset(new DateTime(2026, 8, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicantName", "EndTime", "StartTime" },
                values: new object[] { "Teszt Felhasználó 2", new DateTimeOffset(new DateTime(2026, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ApplicantName", "EndTime", "ParkingSpaceId", "StartTime" },
                values: new object[,]
                {
                    { 3, "Teszt Felhasználó 3", new DateTimeOffset(new DateTime(2026, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 3, new DateTimeOffset(new DateTime(2026, 8, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 4, "Teszt Felhasználó 4", new DateTimeOffset(new DateTime(2026, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 4, new DateTimeOffset(new DateTime(2026, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 5, "Teszt Felhasználó 5", new DateTimeOffset(new DateTime(2026, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 5, new DateTimeOffset(new DateTime(2026, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 6, "Teszt Felhasználó 6", new DateTimeOffset(new DateTime(2026, 8, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 6, new DateTimeOffset(new DateTime(2026, 8, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 7, "Teszt Felhasználó 7", new DateTimeOffset(new DateTime(2026, 8, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 7, new DateTimeOffset(new DateTime(2026, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 8, "Teszt Felhasználó 8", new DateTimeOffset(new DateTime(2026, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 8, new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 9, "Teszt Felhasználó 9", new DateTimeOffset(new DateTime(2026, 8, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 9, new DateTimeOffset(new DateTime(2026, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 10, "Teszt Felhasználó 10", new DateTimeOffset(new DateTime(2026, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 10, new DateTimeOffset(new DateTime(2026, 8, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 11, "Teszt Felhasználó 11", new DateTimeOffset(new DateTime(2026, 8, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 11, new DateTimeOffset(new DateTime(2026, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 12, "Teszt Felhasználó 12", new DateTimeOffset(new DateTime(2026, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 12, new DateTimeOffset(new DateTime(2026, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 13, "Teszt Felhasználó 13", new DateTimeOffset(new DateTime(2026, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 13, new DateTimeOffset(new DateTime(2026, 8, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 14, "Teszt Felhasználó 14", new DateTimeOffset(new DateTime(2026, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 14, new DateTimeOffset(new DateTime(2026, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 15, "Teszt Felhasználó 15", new DateTimeOffset(new DateTime(2026, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 15, new DateTimeOffset(new DateTime(2026, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 16, "Teszt Felhasználó 16", new DateTimeOffset(new DateTime(2026, 8, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 16, new DateTimeOffset(new DateTime(2026, 8, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 17, "Teszt Felhasználó 17", new DateTimeOffset(new DateTime(2026, 8, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 17, new DateTimeOffset(new DateTime(2026, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 18, "Teszt Felhasználó 18", new DateTimeOffset(new DateTime(2026, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 18, new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 19, "Teszt Felhasználó 19", new DateTimeOffset(new DateTime(2026, 8, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 19, new DateTimeOffset(new DateTime(2026, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 20, "Teszt Felhasználó 20", new DateTimeOffset(new DateTime(2026, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 20, new DateTimeOffset(new DateTime(2026, 8, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 21, "Teszt Felhasználó 21", new DateTimeOffset(new DateTime(2026, 8, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 21, new DateTimeOffset(new DateTime(2026, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 22, "Teszt Felhasználó 22", new DateTimeOffset(new DateTime(2026, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 22, new DateTimeOffset(new DateTime(2026, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 23, "Teszt Felhasználó 23", new DateTimeOffset(new DateTime(2026, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 23, new DateTimeOffset(new DateTime(2026, 8, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 24, "Teszt Felhasználó 24", new DateTimeOffset(new DateTime(2026, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 24, new DateTimeOffset(new DateTime(2026, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 25, "Teszt Felhasználó 25", new DateTimeOffset(new DateTime(2026, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 25, new DateTimeOffset(new DateTime(2026, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 26, "Teszt Felhasználó 26", new DateTimeOffset(new DateTime(2026, 8, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 26, new DateTimeOffset(new DateTime(2026, 8, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 27, "Teszt Felhasználó 27", new DateTimeOffset(new DateTime(2026, 8, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 27, new DateTimeOffset(new DateTime(2026, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 28, "Teszt Felhasználó 28", new DateTimeOffset(new DateTime(2026, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 28, new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 29, "Teszt Felhasználó 29", new DateTimeOffset(new DateTime(2026, 8, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 29, new DateTimeOffset(new DateTime(2026, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 30, "Teszt Felhasználó 30", new DateTimeOffset(new DateTime(2026, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 30, new DateTimeOffset(new DateTime(2026, 8, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 31, "Teszt Felhasználó 31", new DateTimeOffset(new DateTime(2026, 8, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 31, new DateTimeOffset(new DateTime(2026, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 32, "Teszt Felhasználó 32", new DateTimeOffset(new DateTime(2026, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 32, new DateTimeOffset(new DateTime(2026, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 33, "Teszt Felhasználó 33", new DateTimeOffset(new DateTime(2026, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 33, new DateTimeOffset(new DateTime(2026, 8, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 34, "Teszt Felhasználó 34", new DateTimeOffset(new DateTime(2026, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 34, new DateTimeOffset(new DateTime(2026, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 35, "Teszt Felhasználó 35", new DateTimeOffset(new DateTime(2026, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 35, new DateTimeOffset(new DateTime(2026, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 36, "Teszt Felhasználó 36", new DateTimeOffset(new DateTime(2026, 8, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 36, new DateTimeOffset(new DateTime(2026, 8, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 37, "Teszt Felhasználó 37", new DateTimeOffset(new DateTime(2026, 8, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 37, new DateTimeOffset(new DateTime(2026, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 38, "Teszt Felhasználó 38", new DateTimeOffset(new DateTime(2026, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 38, new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 39, "Teszt Felhasználó 39", new DateTimeOffset(new DateTime(2026, 8, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 39, new DateTimeOffset(new DateTime(2026, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 40, "Teszt Felhasználó 40", new DateTimeOffset(new DateTime(2026, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 40, new DateTimeOffset(new DateTime(2026, 8, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 41, "Teszt Felhasználó 41", new DateTimeOffset(new DateTime(2026, 8, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 41, new DateTimeOffset(new DateTime(2026, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 42, "Teszt Felhasználó 42", new DateTimeOffset(new DateTime(2026, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 42, new DateTimeOffset(new DateTime(2026, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 43, "Teszt Felhasználó 43", new DateTimeOffset(new DateTime(2026, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 43, new DateTimeOffset(new DateTime(2026, 8, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 44, "Teszt Felhasználó 44", new DateTimeOffset(new DateTime(2026, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 44, new DateTimeOffset(new DateTime(2026, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 45, "Teszt Felhasználó 45", new DateTimeOffset(new DateTime(2026, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 45, new DateTimeOffset(new DateTime(2026, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 46, "Teszt Felhasználó 46", new DateTimeOffset(new DateTime(2026, 8, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 46, new DateTimeOffset(new DateTime(2026, 8, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 47, "Teszt Felhasználó 47", new DateTimeOffset(new DateTime(2026, 8, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 47, new DateTimeOffset(new DateTime(2026, 8, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 48, "Teszt Felhasználó 48", new DateTimeOffset(new DateTime(2026, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 48, new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 49, "Teszt Felhasználó 49", new DateTimeOffset(new DateTime(2026, 8, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 49, new DateTimeOffset(new DateTime(2026, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) },
                    { 50, "Teszt Felhasználó 50", new DateTimeOffset(new DateTime(2026, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 50, new DateTimeOffset(new DateTime(2026, 8, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "ParkingSpaces",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicantName", "EndTime", "StartTime" },
                values: new object[] { "Kovács Péter", new DateTimeOffset(new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 9, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicantName", "EndTime", "StartTime" },
                values: new object[] { "Nagy Anna", new DateTimeOffset(new DateTime(2026, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
