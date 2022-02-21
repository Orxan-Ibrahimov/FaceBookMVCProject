using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FirstMigration282qeeaskl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendId",
                table: "Friends",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Verbinding_EindStad",
                table: "Friends",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verbinding_EindStad",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendId",
                table: "Friends");

            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
