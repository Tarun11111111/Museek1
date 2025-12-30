using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museek.Migrations
{
    /// <inheritdoc />
    public partial class AddBoolPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurated",
                table: "Playlist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Playlist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c89bbbd-44ad-4d01-af62-d6ea0cc4fe65", "AQAAAAIAAYagAAAAECuf4x1xBAi+q1axmDa8CTv/XhqXg5PDkTe8V9BY5GM8A1qGegBQPj00nhXgWCa0oA==", "7aac6d0d-5c86-4ad9-ad33-471ae978772f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurated",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Playlist");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8060dcc-9e4b-46b8-8f52-81c35ea732c5", "AQAAAAIAAYagAAAAELySTfebi1B5/VEFvtZuYge9ZgAbiYAOQTlw9kJJDzK8GjAfSxP/CPOkEH2V9SxNvw==", "ee2c9ec2-7d1f-4b43-b7e2-22afe5b81356" });
        }
    }
}
