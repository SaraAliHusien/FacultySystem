using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultySystem.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class deletedrestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Departments_DepartmentId",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_DepartmentId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Departments_DepartmentId",
                table: "DepartmentSubjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DId",
                table: "Students",
                column: "DId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Departments_DepartmentId",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_DepartmentId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Departments_DepartmentId",
                table: "DepartmentSubjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DId",
                table: "Students",
                column: "DId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
