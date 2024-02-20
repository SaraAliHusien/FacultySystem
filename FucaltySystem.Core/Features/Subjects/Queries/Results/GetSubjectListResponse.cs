namespace FacultySystem.Core.Features.Subjects.Queries.Results
{
    public class GetSubjectListResponse
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Period { get; set; }
        public int StudentsCount { get; set; }
        public int DepartmentsCount { get; set; }
        public int InstructorsCount { get; set; }
    }
}
