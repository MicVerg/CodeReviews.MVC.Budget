using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Budget.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { -6, "Income" },
                    { -5, "Healthcare" },
                    { -4, "Transportation" },
                    { -3, "Entertainment" },
                    { -2, "Utilities" },
                    { -1, "Groceries" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Description", "TransactionType" },
                values: new object[,]
                {
                    { -6, 120.00m, -5, new DateTime(2024, 2, 11, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5908), "Doctor's appointment", 1 },
                    { -5, 60.00m, -4, new DateTime(2024, 2, 18, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5905), "Monthly bus pass", 1 },
                    { -4, 80.00m, -3, new DateTime(2024, 2, 24, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5902), "Dinner with friends", 1 },
                    { -3, 2000.00m, -6, new DateTime(2024, 2, 16, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5900), "Received salary", 0 },
                    { -2, 100.00m, -2, new DateTime(2024, 2, 21, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5896), "Paid electricity bill", 1 },
                    { -1, 50.00m, -1, new DateTime(2024, 2, 23, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5852), "Grocery shopping", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
