using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateSwag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostalCodeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 11, 12, 36, 273, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 11, 12, 36, 273, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 12, 11, 12, 36, 273, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreateDate", "PostalCodeId" },
                values: new object[] { new DateTime(2025, 2, 12, 11, 12, 36, 273, DateTimeKind.Local).AddTicks(2855), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreateDate", "PostalCodeId" },
                values: new object[] { new DateTime(2025, 2, 12, 11, 12, 36, 273, DateTimeKind.Local).AddTicks(2861), 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreateDate", "PostalCodeId" },
                values: new object[] { new DateTime(2025, 2, 12, 11, 12, 36, 273, DateTimeKind.Local).AddTicks(2864), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostalCodeId",
                table: "Users",
                column: "PostalCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PostalCodes_PostalCodeId",
                table: "Users",
                column: "PostalCodeId",
                principalTable: "PostalCodes",
                principalColumn: "PostalCodeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PostalCodes_PostalCodeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PostalCodeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCodeId",
                table: "Users");

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
    }
}
