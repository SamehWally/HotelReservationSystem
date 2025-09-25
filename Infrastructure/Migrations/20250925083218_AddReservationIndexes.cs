using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId_CheckIn",
                table: "Reservations",
                columns: new[] { "RoomId", "CheckIn" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId_CheckOut",
                table: "Reservations",
                columns: new[] { "RoomId", "CheckOut" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId_CheckIn",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId_CheckOut",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }
    }
}
