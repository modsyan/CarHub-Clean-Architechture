using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mac.CarHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "ReleaseRequestId",
                table: "ReleaseDocuments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDocuments_ReleaseRequestId",
                table: "ReleaseDocuments",
                column: "ReleaseRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars",
                column: "ParkingSlotId",
                principalTable: "ParkingSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseDocuments_ReleaseRequests_ReleaseRequestId",
                table: "ReleaseDocuments",
                column: "ReleaseRequestId",
                principalTable: "ReleaseRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseDocuments_ReleaseRequests_ReleaseRequestId",
                table: "ReleaseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ReleaseDocuments_ReleaseRequestId",
                table: "ReleaseDocuments");

            migrationBuilder.DropColumn(
                name: "ReleaseRequestId",
                table: "ReleaseDocuments");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ParkingSlots_ParkingSlotId",
                table: "Cars",
                column: "ParkingSlotId",
                principalTable: "ParkingSlots",
                principalColumn: "Id");
        }
    }
}
