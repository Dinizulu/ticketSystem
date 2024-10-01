using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ticketSystem.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dca9c52-bfed-4384-84b5-9b4a172b4ca5", null, "PM", "PROJECT MANAGER" },
                    { "372b2d3c-a7e5-4fac-8882-183f9c2165e7", null, "ADM", "ADMINISTRATOR" },
                    { "cfacc284-25f7-46a2-aa1c-873e1a653322", null, "RD", "RESEARCH AND DEVELOPMENT" },
                    { "e77d3f2b-c6a8-4ddd-8854-1f6ac4dbc4f8", null, "User", "USER" },
                    { "eabd9ac2-e76f-4cbb-8b35-bfccf9660a6d", null, "QA", "Quality Assurance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dca9c52-bfed-4384-84b5-9b4a172b4ca5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "372b2d3c-a7e5-4fac-8882-183f9c2165e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfacc284-25f7-46a2-aa1c-873e1a653322");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77d3f2b-c6a8-4ddd-8854-1f6ac4dbc4f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eabd9ac2-e76f-4cbb-8b35-bfccf9660a6d");
        }
    }
}
