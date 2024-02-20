using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Commands.Models
{
    public class EditSubjectCommand : IRequest<ResponseBase<string>>
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int Period { get; set; }
    }
}
