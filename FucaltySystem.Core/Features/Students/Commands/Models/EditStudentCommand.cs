
using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<ResponseBase<string>>
    {
        public int StId { get; set; }
        public string StudentName { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string Phone { get; set; } = default!;
        public int? DId { get; set; }



    }
}
