using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Commands.Models
{
    public class CreateSubjectCommand : IRequest<ResponseBase<string>>
    {
        public string SubjectName { get; set; } = default!;

        public int Period { get; set; }

    }
}
