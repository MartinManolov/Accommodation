using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accommodation.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Prce",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "MaxReservations",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxReservations",
                table: "Offers");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prce",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
