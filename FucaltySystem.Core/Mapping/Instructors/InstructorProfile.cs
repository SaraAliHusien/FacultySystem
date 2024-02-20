using AutoMapper;

namespace FacultySystem.Core.Mapping.Instructors
{
    public partial class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            GetInstructorListMapping();
            GetInstructorByIdMapping();
            CreateInstructorMapping();
            EditInstructorMapping();
        }
    }
}
