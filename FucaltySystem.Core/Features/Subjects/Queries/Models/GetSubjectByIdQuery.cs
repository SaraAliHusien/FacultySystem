using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Subjects.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIdQuery : IRequest<ResponseBase<GetSubjectByIdResponse>>
    {
        public int Id { get; set; }
        public GetSubjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
