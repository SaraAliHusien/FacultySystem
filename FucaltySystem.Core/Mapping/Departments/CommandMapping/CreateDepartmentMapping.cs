using FacultySystem.Core.Features.Departments.Commands.Models;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Departments

{
    public partial class DepartmentProfile
    {
        public void CreateDepartmentMapping()
        {
            CreateMap<CreateDepartmentCommand, Department>();
        }
    }
}
