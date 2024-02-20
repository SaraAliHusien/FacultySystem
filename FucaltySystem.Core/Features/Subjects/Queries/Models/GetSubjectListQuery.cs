using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Subjects.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectListQuery : IRequest<ResponseBase<List<GetSubjectListResponse>>>
    {
    }
}
