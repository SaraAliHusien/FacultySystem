using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Commands.Models
{
    public class CreateDepartmentCommand : IRequest<ResponseBase<string>>

    {
        public string DepartmentName { get; set; }
        public int ManagerId { get; set; }


    }
}
