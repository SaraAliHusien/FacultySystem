using AutoMapper;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Instructors.Commands.Models;
using FacultySystem.Data.Enteties;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using MediatR;

namespace FacultySystem.Core.Features.Instructors.Commands.Handlers
{
    public class InstructorCommandHandler : ResponseHandler,
        IRequestHandler<CreateInstructorCommand, ResponseBase<string>>,
        IRequestHandler<EditInstructorCommand, ResponseBase<string>>,
        IRequestHandler<DeleteInstructorCommand, ResponseBase<string>>


    {
        #region fields
        private readonly IInstructorService _instructorService;
        private readonly IDepartmentService _departmentService;

        private readonly IMapper _mapper;

        #endregion
        #region ctros
        public InstructorCommandHandler(IInstructorService instructorService, IDepartmentService departmentService, IMapper mapper)
        //: base(localizerString)
        {
            _instructorService = instructorService;
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public async Task<ResponseBase<string>> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {  //check if Request valide
            if (request is null) return BadRequest<string>();
            if (request.DepartmentId <= 0) return BadRequest<string>();
            var dspartment = await _departmentService.GetByIdWithoutIncludingAsync(request.DepartmentId);
            if (dspartment is null)
                return Failed<string>($"Not found Department has this id: {request.DepartmentId}");
            // mapping
            var instructorMapper = _mapper.Map<Instructor>(request);
            // call add service
            await _instructorService.CreateNewInstructor(instructorMapper);
            return Created(ResponseTypesMatching.CreatedResponse);

        }

        public async Task<ResponseBase<string>> Handle(EditInstructorCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return BadRequest<string>();
            //check if Instructor is founds
            var instructor = await _instructorService.GetByIdWithoutIncludingAsync(request.InstructorId);
            if (instructor is null) return NotFound<string>();


            //check if Department is founds
            if (request.DepartmentId <= 0) return BadRequest<string>();
            var department = await _departmentService.GetByIdWithoutIncludingAsync(request.DepartmentId);
            if (department is null)
                return Failed<string>($"Not found Instructor has this id: {request.DepartmentId}");
            //check if Supervisor is founds
            if (request.SupervisorId is not null)
            {
                if (request.SupervisorId < 0) return BadRequest<string>();
                if (request.SupervisorId > 0)
                {
                    var supervisor = await _instructorService.GetByIdWithoutIncludingAsync(request.SupervisorId.Value);
                    if (supervisor is null)
                        return Failed<string>($"Not found Instructor has this id: {request.SupervisorId}");
                }
                else
                    request.SupervisorId = null;

            }

            // mapping
            var instructorMapper = _mapper.Map(request, instructor);

            // call add service
            await _instructorService.EditAsync(instructorMapper);
            return Success("Updated Successfully");
        }

        public async Task<ResponseBase<string>> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0) return BadRequest<string>();
            //check if id is existing or no
            var instructor = await _instructorService.GetByIdWithoutIncludingAsync(request.Id);
            if (instructor == null)
                return NotFound<string>("Not Found");

            // call delete service
            var result = await _instructorService.DeleteAsync(instructor);
            // return response
            if (result == ResponseTypesMatching.DeletedResponse)
                return Deleted<string>(ResponseTypesMatching.DeletedResponse);
            if (result == ResponseTypesMatching.FailExcuteService)
                return Failed<string>("Cann't Delete this Instructor becouse has relation with Departments or instructors or subjects");
            return BadRequest<string>();
        }


        #endregion
    }
}
