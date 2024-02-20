

using FacultySystem.Core.Features.Students.Commands.Models;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Students
{
    public partial class StudentProfile

    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>().ForMember(des => des.StudentId, opt => opt.MapFrom(src => src.StId));
            //.ForMember(des => des.GetLocalizedProp(des.StudentNameEn, des.StudentNameAr), opt => opt.MapFrom(
            //src => src.StudentName)).ForMember(des => des.GetLocalizedProp(des.AddressEn, des.AddressAr), opt => opt.MapFrom(
            //src => src.Address));
        }
    }
}
