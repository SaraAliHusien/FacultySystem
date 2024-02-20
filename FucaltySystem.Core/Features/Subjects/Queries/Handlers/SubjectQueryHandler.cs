using AutoMapper;
using FacultySystem.Core.Bases;
using FacultySystem.Core.Features.Subjects.Queries.Models;
using FacultySystem.Core.Features.Subjects.Queries.Results;
using FacultySystem.Service.Abstruction;
using MediatR;

namespace FacultySystem.Core.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler,
        IRequestHandler<GetSubjectListQuery, ResponseBase<List<GetSubjectListResponse>>>,
        IRequestHandler<GetSubjectByIdQuery, ResponseBase<GetSubjectByIdResponse>>

    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctors
        public SubjectQueryHandler(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        public async Task<ResponseBase<List<GetSubjectListResponse>>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<List<GetSubjectListResponse>>();
            //Call Service
            var subjects = await _subjectService.GetAllAsync();
            //Check If Dept is exist
            if (subjects is null)
                return NotFound<List<GetSubjectListResponse>>();
            //Mapping
            var subjectsMapper = _mapper.Map<List<GetSubjectListResponse>>(subjects);

            //Return
            return Success(subjectsMapper);
        }


        public async Task<ResponseBase<GetSubjectByIdResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<GetSubjectByIdResponse>();

            //Call Service
            var subject = await _subjectService.GetByIdAsync(request.Id);

            //Check If Dept is exist
            if (subject is null)
                return NotFound<GetSubjectByIdResponse>();
            //Mapping
            var subjectMapper = _mapper.Map<GetSubjectByIdResponse>(subject);
            //Return
            return Success(subjectMapper);
        }
        #endregion
    }
}
