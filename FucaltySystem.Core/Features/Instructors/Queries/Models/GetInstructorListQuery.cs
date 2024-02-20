using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Instructors.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorListQuery : IRequest<ResponseBase<List<GetInstructorListResponse>>>
    {
    }
}
