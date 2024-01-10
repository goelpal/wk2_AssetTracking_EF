using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wk2_AssetTracking_EF.Migrations
{
    public partial class SeedingDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Phone" },
                    { 2, "Computer" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Spain" },
                    { 2, "Sweden" },
                    { 3, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeId", "Brand", "Model", "OfficeId", "PriceInUSD", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, "iPhone", "8", 1, 0.0, new DateTime(2018, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "HP", "Elitebook", 1, 0.0, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "iPhone", "11", 1, 0.0, new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "Motorola", "Razor", 3, 0.0, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssetTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
