using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftOfTheGivers.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImproveDonationTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "Donations",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonationFrequency",
                table: "Donations",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonationStatus",
                table: "Donations",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonationFrequency",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DonationStatus",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "Donations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Donations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
