using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankMVC.Data.Migrations.Postgre
{
    public partial class PostgreSeedUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "balance",
                value: new DateTime(2020, 11, 12, 0, 23, 28, 95, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "balance",
                value: new DateTime(2020, 11, 12, 0, 23, 28, 100, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "balance",
                value: new DateTime(2020, 11, 12, 0, 23, 28, 100, DateTimeKind.Local).AddTicks(3797));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "balance",
                value: new DateTime(2020, 11, 12, 0, 20, 55, 671, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "balance",
                value: new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "balance",
                value: new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "pin", "balance", "UserId", "user_name" },
                values: new object[,]
                {
                    { 4, 555.0, new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5348), null, "user2" },
                    { 5, 777.0, new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5354), null, "user3" }
                });
        }
    }
}
