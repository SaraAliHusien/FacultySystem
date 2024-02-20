


using FacultySystem.Core.Features.Students.Commands.Modals;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Students

{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<CreateStudentCommand, Student>();
            //.ForMember(des => des.GetLocalizedProp(des.StudentNameEn, des.StudentNameAr), opt => opt.MapFrom(
            //src => src.StudentName)).ForMember(des => des.GetLocalizedProp(des.AddressEn, des.AddressAr), opt => opt.MapFrom(
            //src => src.Address));

        }
    }
}
