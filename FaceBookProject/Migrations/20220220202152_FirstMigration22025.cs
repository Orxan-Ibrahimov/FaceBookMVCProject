using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FirstMigration22025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId1",
                table: "UserFriends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends");

            migrationBuilder.RenameTable(
                name: "UserFriends",
                newName: "Friends");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_UserId1",
                table: "Friends",
                newName: "IX_Friends_UserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "UserFriends");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserId1",
                table: "UserFriends",
                newName: "IX_UserFriends_UserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId1",
                table: "UserFriends",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
