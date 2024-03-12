using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Budget.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { -6, 120.00m, -5, new DateTime(2024, 2, 12, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5653), "Doctor's appointment", 1 },
                    { -5, 60.00m, -4, new DateTime(2024, 2, 19, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5650), "Monthly bus pass", 1 },
                    { -4, 80.00m, -3, new DateTime(2024, 2, 25, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5648), "Dinner with friends", 1 },
                    { -3, 2000.00m, -6, new DateTime(2024, 2, 17, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5645), "Received salary", 0 },
                    { -2, 100.00m, -2, new DateTime(2024, 2, 22, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5642), "Paid electricity bill", 1 },
                    { -1, 50.00m, -1, new DateTime(2024, 2, 24, 11, 30, 59, 453, DateTimeKind.Local).AddTicks(5594), "Grocery shopping", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
