using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab01ASPWebApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySeedAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e59c0ade-5a2d-45de-8754-4e96c13ac85d", "e8cbaa8b-92d0-4bab-abd0-23a1712dd9da", "Admin", "admin" },
                    { "f7faf42a-f8fa-43a5-8683-95f363308b61", "68448042-92de-4c84-a69c-a72dd60f9a57", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59c0ade-5a2d-45de-8754-4e96c13ac85d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7faf42a-f8fa-43a5-8683-95f363308b61");
        }
    }
}
