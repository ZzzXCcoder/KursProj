using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProj.Migrations
{
    /// <inheritdoc />
    public partial class CorrectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImages_Courses_CourseID",
                table: "CourseImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_InstructorID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTestAvailabilities_Courses_CourseID",
                table: "CourseTestAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTestAvailabilities_Tests_TestID",
                table: "CourseTestAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonImages_Lessons_LessonID",
                table: "LessonImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_TestID",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Users_UserID",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Questions_QuestionID",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_TestResults_TestResultID",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseID",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UserID",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonStatuses_Lessons_LessonID",
                table: "UserLessonStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonStatuses_Users_UserID",
                table: "UserLessonStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonViews_Lessons_LessonID",
                table: "UserLessonViews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonViews_Users_UserID",
                table: "UserLessonViews");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "UserLessonViews",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserLessonViews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonViews_LessonID",
                table: "UserLessonViews",
                newName: "IX_UserLessonViews_LessonId");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "UserLessonStatuses",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserLessonStatuses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonStatuses_LessonID",
                table: "UserLessonStatuses",
                newName: "IX_UserLessonStatuses_LessonId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "UserCourses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserCourses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "UserCourses",
                newName: "SubscriptionDate");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourses_CourseID",
                table: "UserCourses",
                newName: "IX_UserCourses_CourseId");

            migrationBuilder.RenameColumn(
                name: "TestResultID",
                table: "UserAnswers",
                newName: "TestResultId");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "UserAnswers",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserAnswers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_TestResultID",
                table: "UserAnswers",
                newName: "IX_UserAnswers_TestResultId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuestionID",
                table: "UserAnswers",
                newName: "IX_UserAnswers_QuestionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "TestResults",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "TestResults",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TestResults",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_UserID",
                table: "TestResults",
                newName: "IX_TestResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_TestID",
                table: "TestResults",
                newName: "IX_TestResults_TestId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "Questions",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestID",
                table: "Questions",
                newName: "IX_Questions_TestId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Notifications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Lessons",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Lessons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseID",
                table: "Lessons",
                newName: "IX_Lessons_CourseId");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "LessonImages",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LessonImages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LessonImages_LessonID",
                table: "LessonImages",
                newName: "IX_LessonImages_LessonId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "CourseTestAvailabilities",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseTestAvailabilities",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTestAvailabilities_TestID",
                table: "CourseTestAvailabilities",
                newName: "IX_CourseTestAvailabilities_TestId");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Courses",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorID",
                table: "Courses",
                newName: "IX_Courses_InstructorId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseImages",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CourseImages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CourseImages_CourseID",
                table: "CourseImages",
                newName: "IX_CourseImages_CourseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Answers",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImages_Courses_CourseId",
                table: "CourseImages",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTestAvailabilities_Courses_CourseId",
                table: "CourseTestAvailabilities",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTestAvailabilities_Tests_TestId",
                table: "CourseTestAvailabilities",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonImages_Lessons_LessonId",
                table: "LessonImages",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_TestResults_TestResultId",
                table: "UserAnswers",
                column: "TestResultId",
                principalTable: "TestResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonStatuses_Lessons_LessonId",
                table: "UserLessonStatuses",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonStatuses_Users_UserId",
                table: "UserLessonStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonViews_Lessons_LessonId",
                table: "UserLessonViews",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonViews_Users_UserId",
                table: "UserLessonViews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImages_Courses_CourseId",
                table: "CourseImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTestAvailabilities_Courses_CourseId",
                table: "CourseTestAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTestAvailabilities_Tests_TestId",
                table: "CourseTestAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonImages_Lessons_LessonId",
                table: "LessonImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Tests_TestId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_TestResults_TestResultId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonStatuses_Lessons_LessonId",
                table: "UserLessonStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonStatuses_Users_UserId",
                table: "UserLessonStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonViews_Lessons_LessonId",
                table: "UserLessonViews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonViews_Users_UserId",
                table: "UserLessonViews");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "UserLessonViews",
                newName: "LessonID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLessonViews",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonViews_LessonId",
                table: "UserLessonViews",
                newName: "IX_UserLessonViews_LessonID");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "UserLessonStatuses",
                newName: "LessonID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLessonStatuses",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonStatuses_LessonId",
                table: "UserLessonStatuses",
                newName: "IX_UserLessonStatuses_LessonID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "UserCourses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserCourses",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SubscriptionDate",
                table: "UserCourses",
                newName: "EnrollmentDate");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                newName: "IX_UserCourses_CourseID");

            migrationBuilder.RenameColumn(
                name: "TestResultId",
                table: "UserAnswers",
                newName: "TestResultID");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "UserAnswers",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAnswers",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_TestResultId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_TestResultID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_QuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TestResults",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "TestResults",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TestResults",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_UserId",
                table: "TestResults",
                newName: "IX_TestResults_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_TestId",
                table: "TestResults",
                newName: "IX_TestResults_TestID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Questions",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                newName: "IX_Questions_TestID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notifications",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lessons",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessons",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                newName: "IX_Lessons_CourseID");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "LessonImages",
                newName: "LessonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LessonImages",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_LessonImages_LessonId",
                table: "LessonImages",
                newName: "IX_LessonImages_LessonID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "CourseTestAvailabilities",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseTestAvailabilities",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTestAvailabilities_TestId",
                table: "CourseTestAvailabilities",
                newName: "IX_CourseTestAvailabilities_TestID");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Courses",
                newName: "InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                newName: "IX_Courses_InstructorID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseImages",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CourseImages",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseImages_CourseId",
                table: "CourseImages",
                newName: "IX_CourseImages_CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Answers",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImages_Courses_CourseID",
                table: "CourseImages",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_InstructorID",
                table: "Courses",
                column: "InstructorID",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTestAvailabilities_Courses_CourseID",
                table: "CourseTestAvailabilities",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTestAvailabilities_Tests_TestID",
                table: "CourseTestAvailabilities",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonImages_Lessons_LessonID",
                table: "LessonImages",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseID",
                table: "Lessons",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestID",
                table: "Questions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Tests_TestID",
                table: "TestResults",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Users_UserID",
                table: "TestResults",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Questions_QuestionID",
                table: "UserAnswers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_TestResults_TestResultID",
                table: "UserAnswers",
                column: "TestResultID",
                principalTable: "TestResults",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseID",
                table: "UserCourses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UserID",
                table: "UserCourses",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonStatuses_Lessons_LessonID",
                table: "UserLessonStatuses",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonStatuses_Users_UserID",
                table: "UserLessonStatuses",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonViews_Lessons_LessonID",
                table: "UserLessonViews",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonViews_Users_UserID",
                table: "UserLessonViews",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
