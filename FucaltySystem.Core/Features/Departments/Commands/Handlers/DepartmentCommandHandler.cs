using AutoMapper;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Departments.Commands.Models;
using FacultySystem.Data.Enteties;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using MediatR;

namespace FacultySystem.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : ResponseHandler, IRequestHandler<CreateDepartmentCommand, ResponseBase<string>>,
        IRequestHandler<EditDepartmentCommand, ResponseBase<string>>,
        IRequestHandler<DeleteDepartmentCommand, ResponseBase<string>>

    {
        #region fields
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        //private readonly IStringLocalizer<SharedResource> _localizerString;

        #endregion
        #region ctros
        public DepartmentCommandHandler(IDepartmentService departmentService, IInstructorService instructorServic, IMapper mapper)

        {
            _departmentService = departmentService;
            _instructorService = instructorServic;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            //check if Request valide
            if (request is null) return BadRequest<string>();
            if (request.ManagerId <= 0) return BadRequest<string>();
            var instructor = await _instructorService.GetByIdAsync(request.ManagerId);
            if (instructor is null)
                return Failed<string>($"Not found Instructor has this id: {request.ManagerId}");
            // mapping
            var departmentMapper = _mapper.Map<Department>(request);
            // call add service
            var result = await _departmentService.CreateNewDeppartment(departmentMapper);
            switch (result)
            {
                case ResponseTypesMatching.BadRequestResponse:
                    return BadRequest<string>("Instructor Id must be greater than 0");

                case ResponseTypesMatching.FailFoundFK:
                    return Failed<string>($"Not found Instructor has this id: {request.ManagerId}");
            }
            return Created(ResponseTypesMatching.CreatedResponse);
        }

        public async Task<ResponseBase<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return BadRequest<string>();
            //check if department is founds
            var department = await _departmentService.GetByIdWithoutIncludingAsync(request.DepartmentId);
            if (department is null) return NotFound<string>();
            //check if manger is founds
            if (request.ManagerId <= 0) return BadRequest<string>();
            var instructor = await _instructorService.GetByIdAsync(request.ManagerId);
            if (instructor is null)
                return Failed<string>($"Not found Instructor has this id: {request.ManagerId}");
            // mapping
            var departmentMapper = _mapper.Map(request, department);

            // call add service
            await _departmentService.EditAsync(departmentMapper);
            return Success("Updated Successfully");

        }

        public async Task<ResponseBase<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            //check if id is existing or no
            var department = await _departmentService.GetByIdWithoutIncludingAsync(request.Id);
            if (department == null)
                return NotFound<string>("not found");

            // call delete service
            var result = await _departmentService.DeleteAsync(department);
            // return response
            if (result == ResponseTypesMatching.DeletedResponse)
                return Deleted<string>(ResponseTypesMatching.DeletedResponse);
            if (result == ResponseTypesMatching.FailExcuteService)
                return Failed<string>("Cann't Delete this department becouse has students or instructors or subjects");
            return BadRequest<string>();
        }
    }
}
