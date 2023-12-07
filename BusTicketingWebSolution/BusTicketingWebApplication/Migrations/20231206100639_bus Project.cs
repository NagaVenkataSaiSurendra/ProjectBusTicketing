using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class busProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverAge",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverPhone",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "DriverRating",
                table: "Buses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverAge",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DriverPhone",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DriverRating",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Buses");
        }
    }
}
