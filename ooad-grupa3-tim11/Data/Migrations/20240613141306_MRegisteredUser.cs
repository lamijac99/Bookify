using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class MRegisteredUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RegisteredUser_UserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "RegisteredUserId",
                table: "Reservation",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RegisteredUserId",
                table: "Reservation",
                column: "RegisteredUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RegisteredUser_RegisteredUserId",
                table: "Reservation",
                column: "RegisteredUserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_RegisteredUser_RegisteredUserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RegisteredUserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "RegisteredUserId",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RegisteredUser_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id");
        }
    }
}
