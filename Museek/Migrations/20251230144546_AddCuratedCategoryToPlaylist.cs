using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museek.Migrations
{
    /// <inheritdoc />
    public partial class AddCuratedCategoryToPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CuratedCategory",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a84e2ec1-813b-4329-a315-46ab5409a351", "AQAAAAIAAYagAAAAEArl6f7cyXbesE+qCFfs92zz6f9a0LCAH1YfhOsqwQweqKUwvqG7himm6EvuljkqWg==", "035c63d2-96a7-4bca-be27-9bb32faf3fa0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuratedCategory",
                table: "Playlist");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c89bbbd-44ad-4d01-af62-d6ea0cc4fe65", "AQAAAAIAAYagAAAAECuf4x1xBAi+q1axmDa8CTv/XhqXg5PDkTe8V9BY5GM8A1qGegBQPj00nhXgWCa0oA==", "7aac6d0d-5c86-4ad9-ad33-471ae978772f" });
        }
    }
}
