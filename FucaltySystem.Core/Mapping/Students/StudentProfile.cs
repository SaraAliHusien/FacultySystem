using AutoMapper;

namespace FacultySystem.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
    }
}
