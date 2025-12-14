using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "date_of_birth", "name" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 5, 15), "John Doe" },
                    { 2, new DateOnly(1985, 8, 22), "Jane Smith" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "books",
                columns: new[] { "id", "author", "isbn", "published_date", "title", "user_id" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "978-0132350884", new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Clean Code", 1 },
                    { 2, "Andrew Hunt, David Thomas", "978-0135957059", new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), "The Pragmatic Programmer", 1 },
                    { 3, "Gang of Four", "978-0201633610", new DateTime(1994, 10, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Design Patterns", 2 },
                    { 4, "Eric Evans", "978-0321125215", new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Domain-Driven Design", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "books",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "books",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "books",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "books",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
