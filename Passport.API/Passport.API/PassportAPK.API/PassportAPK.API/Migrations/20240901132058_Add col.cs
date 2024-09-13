using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PassportAPK.API.Migrations
{
    /// <inheritdoc />
    public partial class Addcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9360f098-91cf-43fd-96f1-c2dacab82cac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd27d043-528d-4b89-b954-a4bead9acc78");

            migrationBuilder.AddColumn<string>(
                name: "PassportType",
                table: "MasterDetailsTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74f0983a-7703-43ce-802b-7a1febb7dad5", null, "Admin", "ADMIN" },
                    { "ec1188ab-5869-4a4f-9545-2d5233351aca", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74f0983a-7703-43ce-802b-7a1febb7dad5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec1188ab-5869-4a4f-9545-2d5233351aca");

            migrationBuilder.DropColumn(
                name: "PassportType",
                table: "MasterDetailsTables");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9360f098-91cf-43fd-96f1-c2dacab82cac", null, "User", "USER" },
                    { "fd27d043-528d-4b89-b954-a4bead9acc78", null, "Admin", "ADMIN" }
                });
        }
    }
}
