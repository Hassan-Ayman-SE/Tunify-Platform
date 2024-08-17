using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 5, 12, 16, 9, 416, DateTimeKind.Local).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 7, 26, 12, 16, 9, 416, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "JoinDate",
                value: new DateTime(2024, 7, 16, 12, 16, 9, 416, DateTimeKind.Local).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "JoinDate",
                value: new DateTime(2024, 7, 6, 12, 16, 9, 416, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "JoinDate",
                value: new DateTime(2024, 6, 26, 12, 16, 9, 416, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
