



using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Students.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Students.Queries.Modals
{
    public class GetAllStudentsQuery : IRequest<ResponseBase<List<GetStudentWithDeptName>>>
    {
    }
}
