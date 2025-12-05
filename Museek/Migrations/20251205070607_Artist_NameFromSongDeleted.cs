using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museek.Migrations
{
    /// <inheritdoc />
    public partial class Artist_NameFromSongDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist_Name",
                table: "Song");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6a6c35d-4469-4a5f-80d5-ff46988e8cb5", "AQAAAAIAAYagAAAAEBWXj3hZVf/ae2FkILZs8F5H5Oahg1zReSkQkT8W7oL2epvgSy2EKiuhSG/a8ReG2Q==", "efa92b35-bcfe-4285-a5e3-7bde3fe4638f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist_Name",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e40ff3a8-beeb-48e6-bfb0-9bd3fb471208", "AQAAAAIAAYagAAAAEG2LqN8EJC8gQF+U/1xKfQvgpNZLLiP46KDKoWpES10gQOQ0GPoovnAdcalF6Gsz8w==", "e152a8ef-2fb9-4d8f-8397-04eba90f1845" });
        }
    }
}
