using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FilledEmotionsTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Behaviors_EmotionId1",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_EmotionId1",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "EmotionId1",
                table: "Stories");

            migrationBuilder.AlterColumn<int>(
                name: "EmotionId",
                table: "Stories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_EmotionId",
                table: "Stories",
                column: "EmotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Behaviors_EmotionId",
                table: "Stories",
                column: "EmotionId",
                principalTable: "Behaviors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Behaviors_EmotionId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_EmotionId",
                table: "Stories");

            migrationBuilder.AlterColumn<string>(
                name: "EmotionId",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmotionId1",
                table: "Stories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_EmotionId1",
                table: "Stories",
                column: "EmotionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Behaviors_EmotionId1",
                table: "Stories",
                column: "EmotionId1",
                principalTable: "Behaviors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
