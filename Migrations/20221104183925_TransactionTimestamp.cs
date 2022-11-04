using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class TransactionTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "timestamp",
                table: "Transactions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timestamp",
                table: "Transactions");
        }
    }
}
