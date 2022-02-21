using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FirstMigration282qeeasklk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbinding_EindStad",
                table: "Friends");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendId",
                table: "Friends",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendId",
                table: "Friends");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbinding_EindStad",
                table: "Friends",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
