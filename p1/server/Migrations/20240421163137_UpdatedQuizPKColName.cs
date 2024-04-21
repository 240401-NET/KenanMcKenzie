using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedQuizPKColName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quizId",
                schema: "quiz_schema",
                table: "QuizTag",
                newName: "quiz_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quiz_id",
                schema: "quiz_schema",
                table: "QuizTag",
                newName: "quizId");
        }
    }
}
