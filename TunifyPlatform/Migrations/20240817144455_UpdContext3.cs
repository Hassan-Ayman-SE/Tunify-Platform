using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdContext3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 17, 17, 44, 55, 427, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 7, 17, 44, 55, 427, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "JoinDate",
                value: new DateTime(2024, 7, 28, 17, 44, 55, 427, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "JoinDate",
                value: new DateTime(2024, 7, 18, 17, 44, 55, 427, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "JoinDate",
                value: new DateTime(2024, 7, 8, 17, 44, 55, 427, DateTimeKind.Local).AddTicks(2353));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 17, 13, 18, 13, 560, DateTimeKind.Local).AddTicks(941));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 7, 13, 18, 13, 560, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "JoinDate",
                value: new DateTime(2024, 7, 28, 13, 18, 13, 560, DateTimeKind.Local).AddTicks(959));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "JoinDate",
                value: new DateTime(2024, 7, 18, 13, 18, 13, 560, DateTimeKind.Local).AddTicks(961));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "JoinDate",
                value: new DateTime(2024, 7, 8, 13, 18, 13, 560, DateTimeKind.Local).AddTicks(962));
        }
    }
}
