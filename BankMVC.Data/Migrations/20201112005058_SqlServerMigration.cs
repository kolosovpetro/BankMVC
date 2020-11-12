using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankMVC.Data.Migrations
{
    public partial class SqlServerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pin = table.Column<double>(type: "float", nullable: false),
                    balance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transaction_pkey", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "pin", "balance", "UserId", "user_name" },
                values: new object[,]
                {
                    { 1, 1000.0, new DateTime(2020, 11, 12, 1, 50, 57, 923, DateTimeKind.Local).AddTicks(4399), null, "user1" },
                    { 2, 1000.0, new DateTime(2020, 11, 12, 1, 50, 57, 927, DateTimeKind.Local).AddTicks(9627), null, "user1" },
                    { 3, 1000.0, new DateTime(2020, 11, 12, 1, 50, 57, 927, DateTimeKind.Local).AddTicks(9807), null, "user1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "balance", "pin", "user_name" },
                values: new object[] { 1, 3000.0, "BCDE", "user1" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
