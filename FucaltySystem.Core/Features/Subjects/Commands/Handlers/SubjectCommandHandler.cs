using AutoMapper;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Subjects.Commands.Models;
using FacultySystem.Data.Enteties;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Commands.Handlers
{
    public class SubjectCommandHandler : ResponseHandler,
        IRequestHandler<CreateSubjectCommand, ResponseBase<string>>,
        IRequestHandler<EditSubjectCommand, ResponseBase<string>>,
        IRequestHandler<DeleteSubjectCommand, ResponseBase<string>>


    {

        #region fields
        private readonly ISubjectService _subjectService;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        //private readonly IStringLocalizer<SharedResource> _localizerString;

        #endregion
        #region ctros
        public SubjectCommandHandler(ISubjectService subjectService, IInstructorService instructorServic, IMapper mapper)

        {
            _subjectService = subjectService;
            _instructorService = instructorServic;
            _mapper = mapper;
        }
        #endregion
        public async Task<ResponseBase<string>> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<string>();
            var subjectMapper = _mapper.Map<Subject>(request);
            await _subjectService.CreateNewSubject(subjectMapper);
            return Created(ResponseTypesMatching.CreatedResponse);
        }

        public async Task<ResponseBase<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<string>();
            //check if subject is found
            var subject = await _subjectService.GetByIdWithoutIncludingAsync(request.SubjectId);
            if (subject == null)
                return NotFound<string>();
            //mapping 
            var subjectMapper = _mapper.Map(request, subject);
            // call service
            await _subjectService.EditAsync(subjectMapper);
            //return
            return Success(ResponseTypesMatching.UpdatedResponse);
        }

        public async Task<ResponseBase<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            //check if id is valid value
            if (request == null)
                return BadRequest<string>();
            if (request.Id <= 0) return BadRequest<string>();
            // check if Subject is found
            var subject = await _subjectService.GetByIdWithoutIncludingAsync(request.Id);
            if (subject == null)
                return NotFound<string>();
            // call delete service
            var result = await _subjectService.DeleteAsync(subject);
            if (result == ResponseTypesMatching.FailExcuteService)
                return Failed<string>("Cann't Delete this Subject becouse has relations with Departments or instructors or  Students");
            return Success(ResponseTypesMatching.DeletedResponse);
        }
    }
}
