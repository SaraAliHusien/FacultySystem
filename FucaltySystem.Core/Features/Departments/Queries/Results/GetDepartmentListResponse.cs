namespace FacultySystem.Core.Features.Departments.Queries.Results
{
    public class GetDepartmentListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MangerName { get; set; }
        public int StudentsCount { get; set; }
        public int SubjectsCount { get; set; }
        public int InstructorsCount { get; set; }
    }
}
