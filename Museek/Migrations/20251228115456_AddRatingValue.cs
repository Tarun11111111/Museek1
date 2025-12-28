using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museek.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8060dcc-9e4b-46b8-8f52-81c35ea732c5", "AQAAAAIAAYagAAAAELySTfebi1B5/VEFvtZuYge9ZgAbiYAOQTlw9kJJDzK8GjAfSxP/CPOkEH2V9SxNvw==", "ee2c9ec2-7d1f-4b43-b7e2-22afe5b81356" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Rating");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a49b1b-3c52-4064-9e11-694c1eede0f4", "AQAAAAIAAYagAAAAEJE/XvQyN2yY3NE4agCPC6jAOLeamIdwiwWSHRksODgUzFxe/7dFgKlvc5gnLoc9lQ==", "5871e74e-4426-4042-ab89-562e0a951e4d" });
        }
    }
}
