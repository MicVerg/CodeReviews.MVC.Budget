using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -6,
                column: "Date",
                value: new DateTime(2024, 2, 14, 17, 4, 41, 858, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -5,
                column: "Date",
                value: new DateTime(2024, 2, 21, 17, 4, 41, 858, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -4,
                column: "Date",
                value: new DateTime(2024, 2, 27, 17, 4, 41, 858, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -3,
                column: "Date",
                value: new DateTime(2024, 2, 19, 17, 4, 41, 858, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2024, 2, 24, 17, 4, 41, 858, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 2, 26, 17, 4, 41, 858, DateTimeKind.Local).AddTicks(2958));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -6,
                column: "Date",
                value: new DateTime(2024, 2, 12, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -5,
                column: "Date",
                value: new DateTime(2024, 2, 19, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -4,
                column: "Date",
                value: new DateTime(2024, 2, 25, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -3,
                column: "Date",
                value: new DateTime(2024, 2, 17, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2024, 2, 22, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 2, 24, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5594));
        }
    }
}
