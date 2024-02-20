
using FacultySystem.Core.Bases;
using MediatR;

namespace Faculty.Core.Fratures.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<ResponseBase<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
