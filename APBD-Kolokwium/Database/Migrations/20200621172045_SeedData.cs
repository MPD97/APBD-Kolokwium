using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "test" },
                    { 2, "test" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 16, 19, 20, 44, 788, DateTimeKind.Local).AddTicks(4194), "Tevent", new DateTime(2020, 6, 11, 19, 20, 44, 786, DateTimeKind.Local).AddTicks(1137) },
                    { 2, new DateTime(2020, 7, 6, 19, 20, 44, 788, DateTimeKind.Local).AddTicks(4556), "Tevent", new DateTime(2020, 6, 26, 19, 20, 44, 788, DateTimeKind.Local).AddTicks(4543) }
                });

            migrationBuilder.InsertData(
                table: "ArtistEvents",
                columns: new[] { "IdArtist", "IdEvent", "PerformanceDate" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 14, 19, 20, 44, 788, DateTimeKind.Local).AddTicks(5609) });

            migrationBuilder.InsertData(
                table: "ArtistEvents",
                columns: new[] { "IdArtist", "IdEvent", "PerformanceDate" },
                values: new object[] { 2, 2, new DateTime(2020, 7, 1, 19, 20, 44, 788, DateTimeKind.Local).AddTicks(5917) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdArtist", "IdEvent" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdArtist", "IdEvent" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 2);
        }
    }
}
