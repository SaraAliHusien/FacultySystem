using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Instructors.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorByIdQuery : IRequest<ResponseBase<GetInstructorByIdResponse>>
    {
        public int Id { get; set; }
        public GetInstructorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
