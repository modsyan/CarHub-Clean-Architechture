using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mac.CarHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientNullEnhance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars",
                column: "ParkingSlotId",
                principalTable: "ParkingSlots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars",
                column: "ParkingSlotId",
                principalTable: "ParkingSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
