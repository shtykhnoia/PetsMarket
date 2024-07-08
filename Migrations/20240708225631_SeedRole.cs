using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "429043bc-bcd2-49ec-a735-424afdcb47a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ea49ae8-db8b-4e2f-adb5-7505014f8207");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c726e54-803b-40db-8515-97be18b1ea29", null, "Admin", "ADMIN" },
                    { "fb59316e-40ec-4c27-a24a-42b9cabb4005", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c726e54-803b-40db-8515-97be18b1ea29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb59316e-40ec-4c27-a24a-42b9cabb4005");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "429043bc-bcd2-49ec-a735-424afdcb47a3", null, "User", "USER" },
                    { "9ea49ae8-db8b-4e2f-adb5-7505014f8207", null, "Admin", "ADMIN" }
                });
        }
    }
}
