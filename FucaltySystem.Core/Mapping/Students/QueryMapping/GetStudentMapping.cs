
using FacultySystem.Core.Features.Students.Queries.Results;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentMapping()
        {
            CreateMap<Student, GetStudentWithDeptName>().ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));

        }
    }
}
