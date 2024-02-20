
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Students.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Students.Queries.Modals
{
    public class GetStudentByIdQuery : IRequest<ResponseBase<GetStudentWithDeptName>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
