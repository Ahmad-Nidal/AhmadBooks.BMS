using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmadBooks.BMS.Migrations
{
    /// <inheritdoc />
    public partial class groupdomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppGroups",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_Name",
                table: "AppGroups",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppGroups_Name",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppGroups");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
