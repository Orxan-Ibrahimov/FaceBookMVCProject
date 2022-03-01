using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class addedBehaviorTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "EmotionId",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmotionId1",
                table: "Stories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Behavior",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    EmotionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behavior", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_EmotionId1",
                table: "Stories",
                column: "EmotionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Behavior_EmotionId1",
                table: "Stories",
                column: "EmotionId1",
                principalTable: "Behavior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Behavior_EmotionId1",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Behavior");

            migrationBuilder.DropIndex(
                name: "IX_Stories_EmotionId1",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "EmotionId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "EmotionId1",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "Emotion",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
