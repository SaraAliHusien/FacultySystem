namespace FacultySystem.Core.Features.Instructors.Queries.Results
{
    public class GetInstructorListResponse
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string? DepartmentName { get; set; }
        public string? SupervisorName { get; set; }
    }
}
