namespace Faculty.Core.Fratures.Students.Queries.Results
{
    public class GetStudentsPaginatedListResponse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? DepartmentName { get; set; }
        //public GetStudentsPaginatedListResponse(int id, string name, string address, string phone, string department)
        //{
        //    StudentId = id;
        //    StudentName = name;
        //    Address = address;
        //    Phone = phone;
        //    DepartmentName = department;

        //}
    }
}
