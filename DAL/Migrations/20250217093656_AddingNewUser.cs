using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostalCodes",
                columns: new[] { "PostalCodeId", "Name" },
                values: new object[] { 4, "98765" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 17, 10, 36, 54, 930, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 17, 10, 36, 54, 930, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 2, 17, 10, 36, 54, 930, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 17, 10, 36, 54, 930, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 17, 10, 36, 54, 930, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 17, 10, 36, 54, 930, DateTimeKind.Local).AddTicks(8497));

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCodeId", "Street" },
                values: new object[] { 4, "Kolding", "Denmark", 4, "000 Ang St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostalCodes",
                keyColumn: "PostalCodeId",
                keyValue: 4);

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
    }
}
