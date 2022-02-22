using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class ChangeSuggestaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSuggests");

            migrationBuilder.AddColumn<string>(
                name: "AcceptorId",
                table: "Suggests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Suggests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suggests_AcceptorId",
                table: "Suggests",
                column: "AcceptorId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggests_SenderId",
                table: "Suggests",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggests_AspNetUsers_AcceptorId",
                table: "Suggests",
                column: "AcceptorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggests_AspNetUsers_SenderId",
                table: "Suggests",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggests_AspNetUsers_AcceptorId",
                table: "Suggests");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggests_AspNetUsers_SenderId",
                table: "Suggests");

            migrationBuilder.DropIndex(
                name: "IX_Suggests_AcceptorId",
                table: "Suggests");

            migrationBuilder.DropIndex(
                name: "IX_Suggests_SenderId",
                table: "Suggests");

            migrationBuilder.DropColumn(
                name: "AcceptorId",
                table: "Suggests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Suggests");

            migrationBuilder.CreateTable(
                name: "UserSuggests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuggestId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSuggests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSuggests_Suggests_SuggestId",
                        column: x => x.SuggestId,
                        principalTable: "Suggests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSuggests_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSuggests_SuggestId",
                table: "UserSuggests",
                column: "SuggestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSuggests_UserId1",
                table: "UserSuggests",
                column: "UserId1");
        }
    }
}
