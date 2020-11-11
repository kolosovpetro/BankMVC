using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankMVC.Data.Migrations
{
    public partial class InitialMigration : Migration
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
                    { 1, 1000.0, new DateTime(2020, 11, 11, 14, 28, 58, 827, DateTimeKind.Local).AddTicks(3242), null, "user1" },
                    { 2, 555.0, new DateTime(2020, 11, 11, 14, 28, 58, 832, DateTimeKind.Local).AddTicks(2350), null, "user2" },
                    { 3, 777.0, new DateTime(2020, 11, 11, 14, 28, 58, 832, DateTimeKind.Local).AddTicks(2497), null, "user3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "balance", "pin", "user_name" },
                values: new object[,]
                {
                    { 1, 1000.0, "BCDE", "user1" },
                    { 2, 555.0, "EFGH", "user2" },
                    { 3, 777.0, "EFGH", "user3" }
                });

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
