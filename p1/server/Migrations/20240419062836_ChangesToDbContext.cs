using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Question__belong__6754599E",
                schema: "quiz_schema",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_belongsTo",
                schema: "quiz_schema",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                schema: "quiz_schema",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                schema: "quiz_schema",
                table: "Question",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizId",
                schema: "quiz_schema",
                table: "Question",
                column: "QuizId",
                principalSchema: "quiz_schema",
                principalTable: "Quiz",
                principalColumn: "quiz_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizId",
                schema: "quiz_schema",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuizId",
                schema: "quiz_schema",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizId",
                schema: "quiz_schema",
                table: "Question");

            migrationBuilder.CreateIndex(
                name: "IX_Question_belongsTo",
                schema: "quiz_schema",
                table: "Question",
                column: "belongsTo");

            migrationBuilder.AddForeignKey(
                name: "FK__Question__belong__6754599E",
                schema: "quiz_schema",
                table: "Question",
                column: "belongsTo",
                principalSchema: "quiz_schema",
                principalTable: "Quiz",
                principalColumn: "quiz_id");
        }
    }
}
