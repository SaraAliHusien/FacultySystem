using FacultySystem.Core.Features.Subjects.Queries.Results;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        public void GetSubjectByIdMapping()
        {
            CreateMap<Subject, GetSubjectByIdResponse>().
             ForMember(des => des.StudentsCount, opt => opt.MapFrom(src => src.Students.Count()))
             .ForMember(des => des.StudentsCount, opt => opt.MapFrom(src => src.Students.Count()))
            .ForMember(des => des.DepartmentsCount, opt => opt.MapFrom(src => src.Departments.Count()))
             .ForMember(des => des.InstructorsCount, opt => opt.MapFrom(src => src.Instructors.Count()));
        }
    }
}
