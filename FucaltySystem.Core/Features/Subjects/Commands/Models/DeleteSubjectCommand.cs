using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Commands.Models
{
    public class DeleteSubjectCommand : IRequest<ResponseBase<string>>
    {
        public int Id { get; set; }
        public DeleteSubjectCommand(int id)
        {
            Id = id;
        }
    }
}
