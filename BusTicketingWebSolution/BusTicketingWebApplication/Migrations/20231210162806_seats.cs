using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class seats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "NotificationDateTime",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "BookedSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeatCount",
                table: "BookedSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "BookedSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CancelledBookings",
                columns: table => new
                {
                    CancellationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFare = table.Column<float>(type: "real", nullable: false),
                    CancelledSeats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelledBookings", x => x.CancellationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelledBookings");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "BookedSeats");

            migrationBuilder.DropColumn(
                name: "BookedSeatCount",
                table: "BookedSeats");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BookedSeats");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NotificationDateTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
