using AutoMapper;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Instructors.Queries.Models;
using FacultySystem.Core.Features.Instructors.Queries.Results;
using FacultySystem.Service.Abstruction;
using MediatR;

namespace FacultySystem.Core.Features.Instructors.Queries.Handlers
{
    public class InstructorQueryHandler : ResponseHandler,
        IRequestHandler<GetInstructorListQuery, ResponseBase<List<GetInstructorListResponse>>>,
        IRequestHandler<GetInstructorByIdQuery, ResponseBase<GetInstructorByIdResponse>>

    {
        #region fields
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        //private readonly IStringLocalizer<SharedResource> _localizerString;

        #endregion
        #region ctros
        public InstructorQueryHandler(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<List<GetInstructorListResponse>>> Handle(GetInstructorListQuery request, CancellationToken cancellationToken)
        {
            //call get list service
            var instructors = await _instructorService.GetAllAsync();
            //mapping
            var instructorsMapper = _mapper.Map<List<GetInstructorListResponse>>(instructors);
            //return
            return Success(instructorsMapper);


        }


        public async Task<ResponseBase<GetInstructorByIdResponse>> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<GetInstructorByIdResponse>();

            //Call Service
            var instructor = await _instructorService.GetByIdAsync(request.Id);

            //Check If ins is exist
            if (instructor is null)
                return NotFound<GetInstructorByIdResponse>();
            //Mapping
            var departmentMapper = _mapper.Map<GetInstructorByIdResponse>(instructor);
            //Return
            return Success(departmentMapper);
        }
    }
}
