using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnapMart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MemberCredentialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 21, 20, 17, 7, 213, DateTimeKind.Utc).AddTicks(6529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 15, 18, 20, 37, 2, DateTimeKind.Utc).AddTicks(8472));

            migrationBuilder.CreateTable(
                name: "tbl_MemberCredential",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastPasswordChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MemberCredential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_MemberCredential_tbl_Members_Id",
                        column: x => x.Id,
                        principalTable: "tbl_Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_MemberCredential");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 15, 18, 20, 37, 2, DateTimeKind.Utc).AddTicks(8472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 21, 20, 17, 7, 213, DateTimeKind.Utc).AddTicks(6529));
        }
    }
}
