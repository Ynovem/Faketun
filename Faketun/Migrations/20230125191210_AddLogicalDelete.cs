using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faketun.Migrations
{
    /// <inheritdoc />
    public partial class AddLogicalDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Subjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Semesters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Positions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Instructors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Courses");
        }
    }
}
