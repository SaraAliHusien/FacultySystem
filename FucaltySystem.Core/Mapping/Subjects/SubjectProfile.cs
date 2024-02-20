using AutoMapper;

namespace FacultySystem.Core.Mapping.Subjects
{
    public partial class SubjectProfile : Profile


    {
        public SubjectProfile()
        {
            GetSubjectListMapping();
            GetSubjectByIdMapping();
            CreateSubjectMapping();
            EditSubjectMapping();
        }
    }
}
