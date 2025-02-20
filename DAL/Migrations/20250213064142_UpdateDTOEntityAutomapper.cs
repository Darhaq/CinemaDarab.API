using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDTOEntityAutomapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 13, 7, 41, 41, 992, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 13, 7, 41, 41, 992, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 13, 7, 41, 41, 992, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 13, 7, 41, 41, 992, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 13, 7, 41, 41, 992, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 13, 7, 41, 41, 992, DateTimeKind.Local).AddTicks(3312));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 14, 46, 48, 72, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 14, 46, 48, 72, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 14, 46, 48, 72, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 12, 14, 46, 48, 72, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 12, 14, 46, 48, 72, DateTimeKind.Local).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 12, 14, 46, 48, 72, DateTimeKind.Local).AddTicks(3556));
        }
    }
}
