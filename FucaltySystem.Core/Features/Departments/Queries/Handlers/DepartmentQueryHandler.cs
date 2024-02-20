using AutoMapper;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Departments.Queries.Models;
using FacultySystem.Core.Features.Departments.Queries.Results;
using FacultySystem.Service.Abstruction;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, ResponseBase<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentListQuery, ResponseBase<List<GetDepartmentListResponse>>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctors
        public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        public async Task<ResponseBase<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<GetDepartmentByIdResponse>();

            //Call Service
            var department = await _departmentService.GetByIdAsync(request.Id);

            //Check If Dept is exist
            if (department is null)
                return NotFound<GetDepartmentByIdResponse>();
            //Mapping
            var departmentMapper = _mapper.Map<GetDepartmentByIdResponse>(department);
            //Return
            return Success(departmentMapper);
        }

        public async Task<ResponseBase<List<GetDepartmentListResponse>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<List<GetDepartmentListResponse>>();
            //Call Service
            var departments = await _departmentService.GetAllAsync();
            //Check If Dept is exist
            if (departments is null)
                return NotFound<List<GetDepartmentListResponse>>();
            //Mapping
            var departmentMapper = _mapper.Map<List<GetDepartmentListResponse>>(departments);

            //Return
            return Success(departmentMapper);
        }
        #endregion

    }
}
