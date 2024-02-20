using FacultySystem.Core.Features.Instructors.Commands.Models;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void EditInstructorMapping()
        {
            CreateMap<EditInstructorCommand, Instructor>();
        }
    }
}
