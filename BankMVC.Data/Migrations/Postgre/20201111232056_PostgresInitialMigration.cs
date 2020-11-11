using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BankMVC.Data.Migrations.Postgre
{
    public partial class PostgresInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    pin = table.Column<string>(type: "text", nullable: true),
                    balance = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    pin = table.Column<double>(type: "double precision", nullable: false),
                    balance = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
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
                    { 1, 1000.0, new DateTime(2020, 11, 12, 0, 20, 55, 671, DateTimeKind.Local).AddTicks(5632), null, "user1" },
                    { 2, 1000.0, new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5196), null, "user1" },
                    { 3, 1000.0, new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5337), null, "user1" },
                    { 4, 555.0, new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5348), null, "user2" },
                    { 5, 777.0, new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5354), null, "user3" }
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
