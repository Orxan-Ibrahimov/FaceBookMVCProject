using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class AddedShareTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.AddColumn<int>(
                name: "ShareId",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Stories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ShareId",
                table: "Stories",
                column: "ShareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Stories_ShareId",
                table: "Stories",
                column: "ShareId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Stories_ShareId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_ShareId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ShareId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Stories");

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    StoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shares_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shares_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shares_StoryId",
                table: "Shares",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_UserId",
                table: "Shares",
                column: "UserId");
        }
    }
}
