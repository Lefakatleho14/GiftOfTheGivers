using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftOfTheGivers.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReliefProjectsAndUpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ReliefUpdates");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ReliefUpdates");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ReliefUpdates");

            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "ReliefUpdates",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "ReliefUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ReliefUpdates",
                type: "TEXT",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReliefProjectId",
                table: "ReliefUpdates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReliefProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReliefProjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReliefUpdates_EmployeeId",
                table: "ReliefUpdates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReliefUpdates_ReliefProjectId",
                table: "ReliefUpdates",
                column: "ReliefProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReliefUpdates_AspNetUsers_EmployeeId",
                table: "ReliefUpdates",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReliefUpdates_ReliefProjects_ReliefProjectId",
                table: "ReliefUpdates",
                column: "ReliefProjectId",
                principalTable: "ReliefProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReliefUpdates_AspNetUsers_EmployeeId",
                table: "ReliefUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_ReliefUpdates_ReliefProjects_ReliefProjectId",
                table: "ReliefUpdates");

            migrationBuilder.DropTable(
                name: "ReliefProjects");

            migrationBuilder.DropIndex(
                name: "IX_ReliefUpdates_EmployeeId",
                table: "ReliefUpdates");

            migrationBuilder.DropIndex(
                name: "IX_ReliefUpdates_ReliefProjectId",
                table: "ReliefUpdates");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ReliefUpdates");

            migrationBuilder.DropColumn(
                name: "ReliefProjectId",
                table: "ReliefUpdates");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ReliefUpdates",
                newName: "PublishedAt");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "ReliefUpdates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ReliefUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ReliefUpdates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ReliefUpdates",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
