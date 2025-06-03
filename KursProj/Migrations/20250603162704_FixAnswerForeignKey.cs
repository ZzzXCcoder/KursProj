using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProj.Migrations
{
    /// <inheritdoc />
    public partial class FixAnswerForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionID1",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionID1",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionID1",
                table: "Answers");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionID",
                table: "Answers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionID",
                table: "Answers",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionID",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionID1",
                table: "Answers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionID1",
                table: "Answers",
                column: "QuestionID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionID1",
                table: "Answers",
                column: "QuestionID1",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
