using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class LResID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RegisteredUser_UserIdId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Reservation",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_UserIdId",
                table: "Reservation",
                newName: "IX_Reservation_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RegisteredUser_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RegisteredUser_UserId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservation",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                newName: "IX_Reservation_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RegisteredUser_UserIdId",
                table: "Reservation",
                column: "UserIdId",
                principalTable: "RegisteredUser",
                principalColumn: "Id");
        }
    }
}
