using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FirstMigration282q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserId1",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Friends");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserId",
                table: "Friends");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Friends",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FriendId",
                table: "Friends",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Friends",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId1",
                table: "Friends",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
