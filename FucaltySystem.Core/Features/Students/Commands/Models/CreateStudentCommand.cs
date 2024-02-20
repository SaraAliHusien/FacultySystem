
using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Students.Commands.Modals
{
    public class CreateStudentCommand : IRequest<ResponseBase<string>>
    {
        public string StudentName { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string Phone { get; set; } = default!;
        public int? DId { get; set; }


    }
}
