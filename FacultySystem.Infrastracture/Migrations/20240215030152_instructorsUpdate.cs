using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultySystem.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class instructorsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Instructor_InstructorId1",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_InstructorId1",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstructorId1",
                table: "Instructor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId1",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_InstructorId1",
                table: "Instructor",
                column: "InstructorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Instructor_InstructorId1",
                table: "Instructor",
                column: "InstructorId1",
                principalTable: "Instructor",
                principalColumn: "InstructorId");
        }
    }
}
