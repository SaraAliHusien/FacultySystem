using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Departments.Queries.Results;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<ResponseBase<GetDepartmentByIdResponse>>
    {

        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;

        }

    }
}
