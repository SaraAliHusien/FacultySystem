using FacultySystem.Core.Features.Departments.Queries.Results;

namespace FacultySystem.Core.Mapping.Departments

{
    public partial class DepartmentProfile
    {
        public void GetDepartmentListMapping()
        {
            CreateMap<Data.Enteties.Department, GetDepartmentListResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.DepartmentId)).
                ForMember(des => des.MangerName, opt => opt.MapFrom(src => src.InstructorManager.InstructorName))
            .ForMember(des => des.SubjectsCount, opt => opt.MapFrom(src => src.Subjects.Count()))

            .ForMember(des => des.StudentsCount, opt => opt.MapFrom(src => src.Students.Count()))
            .ForMember(des => des.InstructorsCount, opt => opt.MapFrom(src => src.Instructors.Count()));





        }
    }
}
