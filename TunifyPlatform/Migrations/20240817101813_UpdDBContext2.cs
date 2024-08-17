using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBContext2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 17, 9, 40, 22, 917, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 7, 9, 40, 22, 917, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "JoinDate",
                value: new DateTime(2024, 7, 28, 9, 40, 22, 917, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "JoinDate",
                value: new DateTime(2024, 7, 18, 9, 40, 22, 917, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "JoinDate",
                value: new DateTime(2024, 7, 8, 9, 40, 22, 917, DateTimeKind.Local).AddTicks(8355));
        }
    }
}
