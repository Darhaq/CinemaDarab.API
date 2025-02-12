using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreateDate", "Email" },
                values: new object[] { new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9274), "jane.smith@example.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 11, 8, 9, 32, 996, DateTimeKind.Local).AddTicks(9278));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 6, 13, 29, 7, 813, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 6, 13, 29, 7, 813, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 6, 13, 29, 7, 813, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 6, 13, 29, 7, 813, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreateDate", "Email" },
                values: new object[] { new DateTime(2025, 2, 6, 13, 29, 7, 813, DateTimeKind.Local).AddTicks(6124), "Jane.smith@example.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 6, 13, 29, 7, 813, DateTimeKind.Local).AddTicks(6127));
        }
    }
}
