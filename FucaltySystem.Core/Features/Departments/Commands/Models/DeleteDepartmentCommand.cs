using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand : IRequest<ResponseBase<string>>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
