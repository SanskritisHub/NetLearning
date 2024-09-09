using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Work Today Tomorrow and always..", new DateTime(2024, 9, 5, 13, 6, 45, 671, DateTimeKind.Local).AddTicks(3008), "Work" },
                    { 2, "Travel Today Tomorrow and always..", new DateTime(2024, 9, 5, 13, 6, 45, 671, DateTimeKind.Local).AddTicks(3360), "Travel" },
                    { 3, "Explore Today Tomorrow and always..", new DateTime(2024, 9, 5, 13, 6, 45, 671, DateTimeKind.Local).AddTicks(3362), "Explore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
