using Faculty.Core.Fratures.Students.Queries.Results;
using FacultySystem.Core.Wrappers;
using FacultySystem.Data.Helpers;
using MediatR;

namespace FacultySystem.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedListQuery : IRequest<PaginatedResult<GetStudentsPaginatedListResponse>>
    {
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public StudentOrderingEnum ordering { get; set; }
        public string? search { get; set; }

    }
}
