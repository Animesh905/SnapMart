using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnapMart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OutboxMessageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 15, 18, 13, 16, 513, DateTimeKind.Utc).AddTicks(4233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 15, 17, 22, 49, 642, DateTimeKind.Utc).AddTicks(9400));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 15, 17, 22, 49, 642, DateTimeKind.Utc).AddTicks(9400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 15, 18, 13, 16, 513, DateTimeKind.Utc).AddTicks(4233));
        }
    }
}
