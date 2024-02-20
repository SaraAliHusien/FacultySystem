using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Commands.Models
{
    public class EditDepartmentCommand : IRequest<ResponseBase<string>>
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int ManagerId { get; set; }
    }
}
