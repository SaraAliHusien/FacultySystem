using FacultySystem.Core.Features.Departments.Queries.Results;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Data.Enteties.Department, GetDepartmentByIdResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(des => des.ManagerName, opt => opt.MapFrom(src => src.InstructorManager.InstructorName))
                .ForMember(des => des.SubjectsList, opt => opt.MapFrom(src => src.Subjects))
                .ForMember(des => des.StudentsList, opt => opt.MapFrom(src => src.Students))
                .ForMember(des => des.InstructorsList, opt => opt.MapFrom(src => src.Instructors));
            CreateMap<DepartmentSubject, ListResponse>().
                ForMember(des => des.Id, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Subject.SubjectName));
            CreateMap<Student, ListResponse>().
               ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudentId))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.StudentName));
            CreateMap<Data.Enteties.Instructor, ListResponse>().
               ForMember(des => des.Id, opt => opt.MapFrom(src => src.InstructorId))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.InstructorName));







        }
    }
}
