using FacultySystem.Core.Features.Instructors.Queries.Results;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Instructors

{
    public partial class InstructorProfile
    {
        public void GetInstructorListMapping()
        {
            CreateMap<Instructor, GetInstructorListResponse>().
                ForMember(des => des.SupervisorName, opt => opt.MapFrom(src => src.Supervisor.InstructorName)).
                ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))

                ;
        }
    }
}
