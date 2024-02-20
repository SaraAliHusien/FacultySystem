using FacultySystem.Core.Bases;
using MediatR;

namespace FacultySystem.Core.Features.Instructors.Commands.Models
{
    public class CreateInstructorCommand : IRequest<ResponseBase<string>>
    {
        public string InstructorName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public int? SupervisorId { get; set; }

    }
}
