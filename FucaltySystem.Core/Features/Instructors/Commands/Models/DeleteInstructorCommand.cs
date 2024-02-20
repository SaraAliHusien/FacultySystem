using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Instructors.Commands.Models
{
    public class DeleteInstructorCommand : IRequest<ResponseBase<string>>
    {
        public int Id { get; set; }
        public DeleteInstructorCommand(int id)
        {
            Id = id;
        }
    }
}
