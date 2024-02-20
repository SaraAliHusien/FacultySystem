using AutoMapper;

namespace FacultySystem.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
            GetDepartmentListMapping();
            CreateDepartmentMapping();
            EditDepartmentMapping();


        }
    }
}
