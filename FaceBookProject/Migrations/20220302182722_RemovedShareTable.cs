using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class RemovedShareTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Stories");

            migrationBuilder.AddColumn<int>(
                name: "ShareCount",
                table: "Stories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShareCount",
                table: "Stories");

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Stories",
                type: "int",
                nullable: true);
        }
    }
}
