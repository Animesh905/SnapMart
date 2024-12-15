using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnapMart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OutboxMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 15, 18, 20, 37, 2, DateTimeKind.Utc).AddTicks(8472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 15, 18, 13, 16, 513, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccurredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 15, 18, 13, 16, 513, DateTimeKind.Utc).AddTicks(4233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 15, 18, 20, 37, 2, DateTimeKind.Utc).AddTicks(8472));
        }
    }
}
