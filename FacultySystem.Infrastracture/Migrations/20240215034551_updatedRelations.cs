using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultySystem.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class updatedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId",
                unique: true,
                filter: "[SupervisorId] IS NOT NULL");
        }
    }
}
