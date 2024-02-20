namespace FacultySystem.Core.Features.Departments.Queries.Results
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public List<ListResponse>? StudentsList { get; set; }
        public List<ListResponse>? SubjectsList { get; set; }
        public List<ListResponse>? InstructorsList { get; set; }




    }
    public class ListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
