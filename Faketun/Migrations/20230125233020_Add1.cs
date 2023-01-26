using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faketun.Migrations
{
    /// <inheritdoc />
    public partial class Add1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorsId",
                table: "InstructorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectsId",
                table: "InstructorSubject");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "InstructorSubject",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "InstructorsId",
                table: "InstructorSubject",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSubject_SubjectsId",
                table: "InstructorSubject",
                newName: "IX_InstructorSubject_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorId",
                table: "InstructorSubject",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectId",
                table: "InstructorSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorId",
                table: "InstructorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectId",
                table: "InstructorSubject");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "InstructorSubject",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "InstructorSubject",
                newName: "InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSubject_SubjectId",
                table: "InstructorSubject",
                newName: "IX_InstructorSubject_SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorsId",
                table: "InstructorSubject",
                column: "InstructorsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectsId",
                table: "InstructorSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
