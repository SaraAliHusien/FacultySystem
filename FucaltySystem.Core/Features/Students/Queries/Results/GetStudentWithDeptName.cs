namespace FacultySystem.Core.Features.Students.Queries.Results
{
    public class GetStudentWithDeptName
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? DepartmentName { get; set; }

    }
}
