using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class LReviewID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_RegisteredUser_UserIdId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Review",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserIdId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_RegisteredUser_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "RegisteredUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_RegisteredUser_UserId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Review",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Review",
                newName: "IX_Review_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_RegisteredUser_UserIdId",
                table: "Review",
                column: "UserIdId",
                principalTable: "RegisteredUser",
                principalColumn: "Id");
        }
    }
}
