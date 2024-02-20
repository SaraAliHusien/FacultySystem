using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Departments.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentListQuery : IRequest<ResponseBase<List<GetDepartmentListResponse>>>

    {
    }
}
