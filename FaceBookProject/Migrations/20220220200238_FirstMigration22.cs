using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FirstMigration22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId1",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_UserId1",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserFriends");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "UserFriends",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FriendId1",
                table: "UserFriends",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_FriendId1",
                table: "UserFriends",
                column: "FriendId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_FriendId1",
                table: "UserFriends",
                column: "FriendId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_FriendId1",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_FriendId1",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "FriendId1",
                table: "UserFriends");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserFriends",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserFriends",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserId1",
                table: "UserFriends",
                column: "UserId1");

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
