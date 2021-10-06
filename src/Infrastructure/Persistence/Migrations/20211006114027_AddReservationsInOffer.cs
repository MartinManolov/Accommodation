using Microsoft.EntityFrameworkCore.Migrations;

namespace Accommodation.Infrastructure.Persistence.Migrations
{
    public partial class AddReservationsInOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OfferId",
                table: "Reservations",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Offers_OfferId",
                table: "Reservations",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Offers_OfferId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_OfferId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Reservations");
        }
    }
}
