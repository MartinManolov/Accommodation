using Microsoft.EntityFrameworkCore.Migrations;

namespace Accommodation.Infrastructure.Persistence.Migrations
{
    public partial class RenameDateProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Offers",
                newName: "CheckOutDate");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "Offers",
                newName: "CheckInDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "Offers",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "Offers",
                newName: "FromDate");
        }
    }
}
