using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museek.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAlbumAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Released_Year",
                table: "Album",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleasedDate",
                table: "Album",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlbumSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSong", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88c16223-0817-4fa9-b938-e0f1538ab0b3", "AQAAAAIAAYagAAAAECBa2R6EzLZ58KVaq08Dhp2LqQKDAuf8vFt1u60jMfnGvheh/nS5Gqz2+UlA42MepA==", "ddf6622f-cded-429e-b1da-ed33a919dec7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumSong");

            migrationBuilder.DropColumn(
                name: "ReleasedDate",
                table: "Album");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Album",
                newName: "Released_Year");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a84e2ec1-813b-4329-a315-46ab5409a351", "AQAAAAIAAYagAAAAEArl6f7cyXbesE+qCFfs92zz6f9a0LCAH1YfhOsqwQweqKUwvqG7himm6EvuljkqWg==", "035c63d2-96a7-4bca-be27-9bb32faf3fa0" });
        }
    }
}
