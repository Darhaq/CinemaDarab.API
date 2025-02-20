using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 9, 2, 38, 139, DateTimeKind.Local).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 9, 2, 38, 139, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 9, 2, 38, 139, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 12, 9, 2, 38, 139, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 12, 9, 2, 38, 139, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 12, 9, 2, 38, 139, DateTimeKind.Local).AddTicks(5689));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9278));
        }
    }
}
