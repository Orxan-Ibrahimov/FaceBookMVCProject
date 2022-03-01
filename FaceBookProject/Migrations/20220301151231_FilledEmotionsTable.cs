using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceBookProject.Migrations
{
    public partial class FilledEmotionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Behavior_EmotionId1",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Behavior",
                table: "Behavior");

            migrationBuilder.RenameTable(
                name: "Behavior",
                newName: "Behaviors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Behaviors",
                table: "Behaviors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Behaviors",
                columns: new[] { "Id", "EmotionType", "Icon", "Text" },
                values: new object[,]
                {
                    { 1, 1, "happy.png", "happy" },
                    { 27, 1, "threatened.png", "threatened" },
                    { 28, 1, "thirsty.png", "thirsty" },
                    { 29, 1, "super.png", "super" },
                    { 30, 1, "smart.png", "smart" },
                    { 31, 1, "scared.png", "scared" },
                    { 32, 1, "rich.png", "rich" },
                    { 33, 1, "perplexed.png", "perplexed" },
                    { 34, 1, "numb.png", "numb" },
                    { 35, 1, "naked.png", "naked" },
                    { 26, 1, "trapped.png", "trapped" },
                    { 36, 1, "invisible.png", "invisible" },
                    { 38, 1, "furious.png", "furious" },
                    { 39, 1, "funny.png", "funny" },
                    { 40, 1, "embarassed.png", "embarassed" },
                    { 41, 1, "cold.png", "cold" },
                    { 42, 1, "broken.png", "broken" },
                    { 43, 1, "hopeful.png", "hopeful" },
                    { 44, 1, "sarcastic.png", "sarcastic" },
                    { 45, 1, "heartbroken.png", "heartbroken" },
                    { 46, 1, "bored.png", "bored" },
                    { 37, 1, "inspired.png", "inspired" },
                    { 25, 1, "worried.png", "worried" },
                    { 24, 1, "safe.png", "safe" },
                    { 23, 1, "sad.png", "sad" },
                    { 2, 1, "loved.png", "loved" },
                    { 3, 1, "alone.png", "alone" },
                    { 4, 1, "OK.png", "OK" },
                    { 5, 1, "sick.png", "sick" },
                    { 6, 1, "thoughtful.png", "thoughtful" },
                    { 7, 1, "motivated.png", "motivated" },
                    { 8, 1, "cool.png", "cool" },
                    { 9, 1, "thankful.png", "thankful" },
                    { 10, 1, "inLove.png", "in-love" },
                    { 11, 1, "crazy.png", "crazy" },
                    { 12, 1, "relaxed.png", "relaxed" },
                    { 13, 1, "blissful.png", "blissful" },
                    { 14, 1, "excited.png", "excited" },
                    { 15, 1, "festive.png", "festive" },
                    { 16, 1, "fantastic.png", "fantastic" },
                    { 17, 1, "grateful.png", "grateful" },
                    { 18, 1, "blessed.png", "blessed" },
                    { 19, 1, "lovely.png", "lovely" },
                    { 20, 1, "wonderful.png", "wonderful" },
                    { 21, 1, "amused.png", "amused" },
                    { 22, 1, "silly.png", "silly" },
                    { 47, 1, "beautiful.png", "beautiful" },
                    { 48, 1, "irritated.png", "irritated" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Behaviors_EmotionId1",
                table: "Stories",
                column: "EmotionId1",
                principalTable: "Behaviors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Behaviors_EmotionId1",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Behaviors",
                table: "Behaviors");

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Behaviors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.RenameTable(
                name: "Behaviors",
                newName: "Behavior");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Behavior",
                table: "Behavior",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Behavior_EmotionId1",
                table: "Stories",
                column: "EmotionId1",
                principalTable: "Behavior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
